using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    public float curHealth;
    public GameObject floatingHealthPrefab;
    public float xpWorth = 10;
    public GameObject xpPrefab;
    public float xpDropChance = 5;
    public GameObject healPrefab;
    public float healDropChance = 1;
    public int healWorth = 10;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }
    public void Damage(float amount)
    {
        curHealth -= amount;
        showFloatingText(amount);
        if (curHealth <= 0)
        {
            bool spawnedXP = spawnXP();
            if (!spawnedXP)
            {
                spawnHealth();
            }
            Destroy(gameObject);
        }
    }



    private void showFloatingText(float amount)
    {
        var floatingText = Instantiate(floatingHealthPrefab, transform.position, Quaternion.identity, transform);
        //var floatingText = Instantiate(floatingHealthPrefab, transform.position, Quaternion.identity);
        //floatingText.transform.position = transform.position;


        if (amount >20 && amount < 30)
        {
            floatingText.GetComponent<TextMesh>().color = Color.yellow;
        }
        if (amount >= 30)
        {
            floatingText.GetComponent<TextMesh>().color = Color.red;
        }
       
        floatingText.GetComponent<TextMesh>().text = amount.ToString();
    }
    public void setXPWorth(float xpAmount)
    {
        xpWorth = xpAmount;
    }
    public void setXPDropChance(float dropChance)
    {
        xpDropChance = dropChance;
    }
    public void setHealWorth(float healAmount)
    {
        healAmount = healWorth;
    }
    public void setHealDropChance(float dropChance)
    {
        healDropChance = dropChance;
    }
    private bool spawnXP()
    {

        var xpDropChanceValue = UnityEngine.Random.Range(0, 10);
        if (xpDropChanceValue <= xpDropChance)
        {
            var xpDrop = Instantiate(xpPrefab, transform.position, Quaternion.identity);
            xpDrop.GetComponent<XPDropScript>().SetXPValue(xpWorth);
            return true;
        }
        return false;

    }
    private void spawnHealth()
    {
        var healDropChanceValue = UnityEngine.Random.Range(0, 10);
        if (healDropChanceValue <= healDropChance)
        {
            var healDrop = Instantiate(healPrefab, transform.position, Quaternion.identity);
            healDrop.GetComponent<HealthDropScript>().SetHealValue(healWorth);

        }

    }
}
