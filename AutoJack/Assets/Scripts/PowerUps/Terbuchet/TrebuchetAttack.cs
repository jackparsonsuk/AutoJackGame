using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrebuchetAttack : MonoBehaviour
{
    private int damage =25;
    private float attackSpeed = 0.1f;
    private GameObject attackPoint;
    public bool CanAttack = true;
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

        attackPoint = transform.Find("AttackPoint").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var haveTarget= transform.gameObject.GetComponent<TrebuchetMove>().target != null;
        if (CanAttack && haveTarget)
        {
            var bullet = Instantiate(BulletPrefab, attackPoint.transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().SetDamage(damage);
            bullet.GetComponent<Bullet>().SetDamageVariation(false);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.transform.up * 5 , ForceMode2D.Impulse);
            StartCoroutine(Cooldown());
        }
    }

    internal void setDamage(int trebuchetDamage)
    {
        damage = trebuchetDamage;
    }

    internal void SetAttackSpeed(float trebuchetAttackSpeed)
    {
        attackSpeed =  trebuchetAttackSpeed;
    }

    private IEnumerator Cooldown()
    {
        // Start cooldown
        CanAttack = false;
        // Wait for time you want
        yield return new WaitForSeconds(attackSpeed);
        // Stop cooldown
        CanAttack = true;
    }
}
