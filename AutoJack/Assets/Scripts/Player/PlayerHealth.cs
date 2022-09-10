using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float curHealth;
    public GameObject gameController;
    public GameObject DeathText;
    public GameObject HealthBar;
    public GameObject RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        curHealth = maxHealth;
        updateHealthGUI();
        RestartButton.GetComponent<Button>().onClick.AddListener(RestartGameButtonCall);
    }
    public void damage(int amount)
    {
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

    private void GameOver()
    {
        DeathText.SetActive(true);
        RestartButton.SetActive(true);
        Time.timeScale = 0.00001f;
    }
    private void updateHealthGUI()
    {
        HealthBar.gameObject.GetComponent<Slider>().value = (curHealth /maxHealth);
    }
    void RestartGameButtonCall()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
