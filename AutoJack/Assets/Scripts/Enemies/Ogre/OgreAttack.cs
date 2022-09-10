using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float AttackSpeed = 2f;
    public int AttackDamage = 5;
    public bool CanAttack = true;
    public GameObject rockPrefab;
    private bool PlayerInRange;
    private GameObject attackPoint;

    void Start()
    {
        attackPoint = transform.Find("AttackPoint").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerInRange = gameObject.GetComponent<OgreMove>().PlayerInRange();
        if (CanAttack && PlayerInRange)
        {
            var RockIn = Instantiate(rockPrefab, attackPoint.transform.position, transform.rotation);
            RockIn.GetComponent<Rock>().SetDamage(30);
            Rigidbody2D rb = RockIn.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.transform.up * 20, ForceMode2D.Impulse);
            int spinAttackOdds = UnityEngine.Random.Range(0, 2);
            if (spinAttackOdds == 1)
            {
                spinAttack();
            }
            StartCoroutine(Cooldown());
        }
    }

    private void spinAttack()
    {
        for (int i = 0; i < 6; i++)
        {
            var rotation = i * 60;
            var RockIn = Instantiate(rockPrefab, attackPoint.transform.position, transform.rotation);
            rockPrefab.transform.Rotate(new Vector3(0,0,rotation));
            RockIn.GetComponent<Rock>().SetDamage(50);
            Rigidbody2D rb = RockIn.GetComponent<Rigidbody2D>();
            rb.AddForce(rockPrefab.transform.up * 20, ForceMode2D.Impulse);
        }
    }

    private IEnumerator Cooldown()
    {
        // Start cooldown
        CanAttack = false;
        // Wait for time you want
        yield return new WaitForSeconds(AttackSpeed);
        // Stop cooldown
        CanAttack = true;
    }
}
