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
    public GameObject levelTextPrefab;
    public Slider XPSlider;
    public int timesToShowPowerUpOptions = 0;

    private void Start()
    {
        addXP(101);
        refreshUIElements();
    }
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
        refreshUIElements();
    }

    private void refreshUIElements()
    {
        var lastXPThreshold = CalculateThreshold(currentLevel - 1);
        XPSlider.value = ((currentXP-lastXPThreshold) / (xpThreshold-lastXPThreshold));

        levelTextPrefab.GetComponent<TextMeshProUGUI>().text = "Current Level: " + (currentLevel-1).ToString();
    }

    private void IncreaseLevel()
    {
        currentLevel++;
        //Give powerUp options
        if (timesToShowPowerUpOptions == 0)
        {
            if (currentLevel-1 == 1)
            {
                print("level 2");
                showPowerUpOptions(true);
            }
            else
            {
                print("other level");
                timesToShowPowerUpOptions++;
                showPowerUpOptions(false);
            }

        }
        else
        {
            timesToShowPowerUpOptions++;
        }

    }

    private void IncreaseXPThreshold()
    {
        xpThreshold = CalculateThreshold(currentLevel);
    }
    public int CalculateThreshold(int level)
    {
        switch (level)
        {
            case 1:
                return 100;
            case 2:
                return 250;
            case 3:
                return 600;
            case 4:
                return 1500;
            case 5:
                return 3000;
            case 6:
                return 6000;
            case 7:
                return 9000;
            case 8:
                return 12000;
            case 9:
                return 15000;
            case 10:
                return 18000;
            case 11:
                return 21000;
            case 12:
                return 24000;
            default:
                return 0;
        }
    }


    private void showPowerUpOptions(bool allAttackingChoices)
    {
        //Freeze screen
        FreezeGame(true);
        //Genearate 3 upgrade options
        for (int i = 0; i < 3; i++)
        {
            var upgradeChoice = 0;
            if (allAttackingChoices)
            {
                upgradeChoice = UnityEngine.Random.Range(0, 3);
            }
            else
            {
                upgradeChoice = UnityEngine.Random.Range(0, 5);
            }

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
            else if (upgradeChoice == 3)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade player health";
                button.GetComponent<Button>().onClick.AddListener(playerHealthUpgradeButtonCall);
            }
            else if (upgradeChoice == 4)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade player speed";
                button.GetComponent<Button>().onClick.AddListener(playerSpeedUpgradeButtonCall);
            }

            upgradeButtons.Add(button);


        }



    }

    private void FreezeGame(bool frozen)
    {
        if (frozen)
        {
            Time.timeScale = 0.001f;
        }
        else
        {
            Time.timeScale = 1f;
        }

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
    void playerHealthUpgradeButtonCall()
    {
        powerUpController.UpgradePowerUp(PowerUpController.PowerUpType.playerHealth);
        clearUpgradeButtons();
    }
    void playerSpeedUpgradeButtonCall()
    {
        powerUpController.UpgradePowerUp(PowerUpController.PowerUpType.playerSpeed);
        clearUpgradeButtons();
    }
    void clearUpgradeButtons()
    {
        Debug.Log("clear power ups");


        foreach (var item in upgradeButtons)
        {
            Destroy(item);
        }
        upgradeButtons.Clear();
        timesToShowPowerUpOptions--;
        if (timesToShowPowerUpOptions > 0)
        {
            showPowerUpOptions(false);
        }
        //Unfreeze screen
        FreezeGame(false);
    }
}
