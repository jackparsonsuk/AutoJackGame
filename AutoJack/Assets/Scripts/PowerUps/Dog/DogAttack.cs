using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    public int AttackDamage = 0;
    public float AttackSpeed = 2f;
    public bool CanAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void setDamage(int dogDamage)
    {
        AttackDamage = dogDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && CanAttack)
        {
            collision.transform.GetComponent<EnemyHealth>().Damage(AttackDamage);
            StartCoroutine(Cooldown());
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

    internal void SetAttackSpeed(float dogAttackSpeed)
    {
        AttackSpeed = dogAttackSpeed;
    }
}
