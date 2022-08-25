using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamage : MonoBehaviour
{
    float damage = 25f;
    
    public void setDamage(float newDamage)
    {
        damage = newDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyHealth>().Damage(damage);
        }
    }
}
