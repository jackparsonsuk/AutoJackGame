using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float curDamage = 10f;
    public bool damageVariation = false;
    public float damageVariationAmount =3;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            var health = collision.transform.GetComponent<EnemyHealth>();

            if (damageVariation)
            {
                var varAmount = Random.Range(-damageVariationAmount, damageVariationAmount);
                var varDamage = curDamage + varAmount;
                if (varDamage < 0)
                {
                    varDamage = 1;
                }
                varDamage = Mathf.Round(varDamage);
                health.Damage(varDamage);

            }
            else
            {
                health.Damage(curDamage);
            }
            Destroy(gameObject);
        }
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

    }

    public void SetDamage(int damage)
    {
        curDamage = damage;
    }
    public void SetDamageVariation(bool on)
    {
        damageVariation = on;
    }
}
