using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropScript : MonoBehaviour
{
    public int healAmount = 10;
    public void SetHealValue(int newHealValue)
    {
        healAmount = newHealValue;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().heal(healAmount);
            Destroy(gameObject);
        }
    }
}
