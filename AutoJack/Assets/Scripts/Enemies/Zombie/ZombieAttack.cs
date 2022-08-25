using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float AttackSpeed = 2f;
    public int AttackDamage = 5;
    public bool CanAttack = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && CanAttack)
        {
            collision.transform.GetComponent<PlayerHealth>().damage(AttackDamage, transform.gameObject);
            StartCoroutine(Cooldown());
        }
    }
    public void changeAttackSpeed(int speed)
    {
        AttackSpeed = speed;
    }
    public void changeAttackDamage(int damage)
    {
        AttackDamage = damage;
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
