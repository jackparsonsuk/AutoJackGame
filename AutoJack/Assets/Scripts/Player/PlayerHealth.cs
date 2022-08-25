using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float curHealth;
    public GameObject gameController;
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
            Debug.Log("GAME OVER");
            GameOver();
        }
    }
    public void heal(int amount, GameObject healer)
    {
        Debug.Log("HEALED BY " + healer.name + " FOR " + amount);
        curHealth += amount;
        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
        updateHealthGUI();
    }
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    private void GameOver()
    {
        throw new NotImplementedException();
    }
    private void updateHealthGUI()
    {
        gameController.GetComponent<WavesController>().updateHealthText(curHealth.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
