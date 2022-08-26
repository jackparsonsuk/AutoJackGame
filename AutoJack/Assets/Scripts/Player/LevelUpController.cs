using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour
{
    public int currentLevel = 1;
    public float xpThreshold = 100;
    public float currentXP = 0;
    public int maxLevel = 10;
    public GameObject upgradeButton;
    public GameObject canvas;
    public PowerUpController powerUpController;
    private List<GameObject> upgradeButtons = new List<GameObject>();
    public List<GameObject> buttonSpawnPoints = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            addXP(100);
        }
    }
    public void addXP(float amount)
    {
        if (currentLevel < maxLevel)
        {
            currentXP += amount;
            if (currentXP > xpThreshold)
            {
                //Level up
                IncreaseLevel();
                //Increase XP to next level
                IncreaseXPThreshold();
            }
        }
    }


    private void IncreaseLevel()
    {
        currentLevel++;
        //Give powerUp options
        showPowerUpOptions();
    }

    private void IncreaseXPThreshold()
    {
        switch (currentLevel)
        {
            case 1:
                xpThreshold = 100;
                break;
            case 2:
                xpThreshold = 250;
                break;
            case 3:
                xpThreshold = 600;
                break;
            case 4:
                xpThreshold = 1500;
                break;
            case 5:
                xpThreshold = 3000;
                break;
            case 6:
                xpThreshold = 5000;
                break;
            default:
                break;
        }
    }


    private void showPowerUpOptions()
    {
        //Freeze screen

        //Genearate 3 upgrade options
        for (int i = 0; i < 3; i++)
        {

            var upgradeChoice = UnityEngine.Random.Range(0,3);
            //Popup upgrade option buttons
            var button = Instantiate(upgradeButton, buttonSpawnPoints[i].transform.position, Quaternion.identity, canvas.transform);


            if (upgradeChoice == 0)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade trebuchets";
                button.GetComponent<Button>().onClick.AddListener(trebuchetUpgradeButtonCall);
            }
            else if (upgradeChoice == 1)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade dogs";
                button.GetComponent<Button>().onClick.AddListener(dogUpgradeButtonCall);
            }
            else if (upgradeChoice == 2)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade shield";
                button.GetComponent<Button>().onClick.AddListener(shieldUpgradeButtonCall);
            }

            upgradeButtons.Add(button);


        }


        //Unfreeze screen
    }
    void setupButton()
    {
        Debug.Log("BUTTON PRESSED");
    }

    void dogUpgradeButtonCall()
    {

        powerUpController.UpgradePowerUp(PowerUpController.PowerUpType.dog);

        clearUpgradeButtons();
    }
    void trebuchetUpgradeButtonCall()
    {
        powerUpController.UpgradePowerUp(PowerUpController.PowerUpType.trebuchet);
        clearUpgradeButtons();
    }
    void shieldUpgradeButtonCall()
    {
        powerUpController.UpgradePowerUp(PowerUpController.PowerUpType.shield);
        clearUpgradeButtons();
    }
    void clearUpgradeButtons()
    {
        foreach (var item in upgradeButtons)
        {
            Destroy(item);
        }
        upgradeButtons.Clear();
    }
}