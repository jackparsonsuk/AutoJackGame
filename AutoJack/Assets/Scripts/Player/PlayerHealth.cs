using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float curHealth;
    public GameObject gameController;
    public GameObject DeathText;
    public GameObject HealthText;
    public GameObject MaxHealthText;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        curHealth = maxHealth;
        updateHealthGUI();
    }
    public void damage(int amount, GameObject attacker)
    {
        Debug.Log("DAMAGED BY " + attacker.name + " FOR " + amount);
        curHealth -= amount;
        updateHealthGUI();
        if (curHealth <= 0)
        {
            curHealth = 0;
            Debug.Log("GAME OVER");
            GameOver();
        }
    }
    public void heal(int amount)
    {
        curHealth += amount;
        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
        updateHealthGUI();
    }
    public void increaseMaxHealth(int increaseAmount)
    {
        maxHealth+= increaseAmount;
        heal(increaseAmount);
        updateHealthGUI();
    }
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    private void GameOver()
    {
        DeathText.SetActive(true);
    }
    private void updateHealthGUI()
    {
        HealthText.GetComponent<TextMeshProUGUI>().text = curHealth.ToString();
        MaxHealthText.GetComponent<TextMeshProUGUI>().text = maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
