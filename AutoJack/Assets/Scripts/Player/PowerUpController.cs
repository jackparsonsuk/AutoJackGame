using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [Header("General Settings")]
    public float health = 0;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    [Header("Power up 1 settings")]
    public bool pu1Enabled;
    public int pu1NumberOfBullets = 3;

    [Header("Power up 2 settings")]
    public bool pu2Enabled;
    public float pu2FireRate = 2f;

    [Header("Dog power up settings")]
    public bool dogsEnabled;
    public int dogsLevel = 1;
    public int maxDogs = 1;
    public int curNumberOfDogs = 0;
    private int dogDamage;
    private int dogSpeed;
    private float dogAttackSpeed;
    public GameObject dogPrefab;
    List<GameObject> dogs = new List<GameObject>();

    [Header("Trebuchet settings")]
    List<GameObject> Trebuchets = new List<GameObject>();
    public bool TrebuchetEnabled = false;
    public int trebuchetLevel = 1;
    public int maxTrebuchet = 1;
    private float trebuchetTurnSpeed;
    private int trebuchetDamage;
    private int trebuchetLifetime;
    private float trebuchetAttackSpeed;
    public GameObject trebuchetPrefab;
    private bool spawnTrebuchetCooldown;

    [Header("Shield settings")]
    List<GameObject> Shields = new List<GameObject>();
    public bool ShieldEnabled = false;
    public int shieldLevel = 1;
    public int maxShield = 1;
    private float shieldTurnSpeed;
    private int shieldDamage;
    public GameObject shieldPrefab;

    [Header("Player health upgrade")]
    public int PlayerHealthUpgradeLevel = 0;

    [Header("Player Speed upgrade")]
    public int PlayerSpeedUpgradeLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (dogsEnabled)
        {
            if (curNumberOfDogs < maxDogs)
            {
                curNumberOfDogs+= 1;
                spawnDogs(1);
            }
        }
        if (TrebuchetEnabled)
        {

            if (Trebuchets.Count < maxTrebuchet && spawnTrebuchetCooldown == false)
            {
                StartCoroutine(spawnTrebuchet());
            }
        }
        if (ShieldEnabled)
        {
            if (Shields.Count < maxShield)
            {
                SpawnShield();
            }
        }
    }









    #region DogPowerUps

    public void DisableDogs()
    {
        dogsEnabled = false;
    }
    public void DownGradeDogLevel()
    {
        dogsLevel--;
        SetDogStats();
    }
    public void SetDogLevel(int level)
    {
        dogsLevel = level;
        SetDogStats();
    }

    private void SetDogStats()
    {
        switch (dogsLevel)
        {
            case 1:
                dogSpeed = 4;
                dogDamage = 30;
                dogAttackSpeed = 2f;
                maxDogs = 1;
                break;
            case 2:
                dogSpeed = 6;
                dogDamage = 45;
                dogAttackSpeed = 1f;
                maxDogs = 1;
                break;
            case 3:
                dogSpeed = 7;
                dogAttackSpeed = 0.5f;
                dogDamage = 60;
                maxDogs = 2;
                break;
            case 4:
                dogSpeed = 10;
                dogAttackSpeed = 0.25f;
                dogDamage = 80;
                maxDogs = 3;
                break;
            case 5:
                dogSpeed = 10;
                dogAttackSpeed = 0.1f;
                dogDamage = 90;
                maxDogs = 5;
                break;
            default:
                break;
        }
        foreach (GameObject item in dogs)
        {
            item.GetComponent<DogMove>().setSpeed(dogSpeed);
            item.GetComponent<DogAttack>().setDamage(dogDamage);
            item.GetComponent<DogAttack>().SetAttackSpeed(dogAttackSpeed);
        }
    }

    private void spawnDogs(int numberOfDogs)
    {

        //Instantaite dog
        var newDog = Instantiate(dogPrefab, transform.position, Quaternion.identity);
        Debug.Log("SPAWNY DOGY");
        //Set dog settings  (Speed, damage) but getting dog attack script on prefab
        dogs.Add(newDog);
        //Set current dog settings (Save dog prefabs in a list and update them all??)
        SetDogStats();

    }

    #endregion
    #region TrebuchetPowerUp

    public void DisableTrebuchet()
    {
        TrebuchetEnabled = false;
    }
    public void DownGradeTrebuchetLevel()
    {
        trebuchetLevel--;
        SetTrebuchetStats();
    }
    public void SetTrebuchetLevel(int level)
    {
        trebuchetLevel = level;
        SetTrebuchetStats();
    }

    private void SetTrebuchetStats()
    {
        switch (trebuchetLevel)
        {
            case 1:
                maxTrebuchet = 1;
                trebuchetTurnSpeed = 0.3f;
                trebuchetAttackSpeed = 2;
                trebuchetDamage = 10;
                trebuchetLifetime = 20;
                break;
            case 2:
                maxTrebuchet = 3;
                trebuchetTurnSpeed = 0.7f;
                trebuchetAttackSpeed = 1;
                trebuchetDamage = 25;
                trebuchetLifetime = 25;
                break;
            case 3:
                maxTrebuchet = 5;
                trebuchetTurnSpeed = 1f;
                trebuchetAttackSpeed = 0.5f;
                trebuchetDamage = 40;
                trebuchetLifetime = 30;
                break;
            case 4:
                maxTrebuchet = 10;
                trebuchetTurnSpeed = 5f;
                trebuchetAttackSpeed = 0.25f;
                trebuchetDamage = 80;
                trebuchetLifetime = 60;
                break;
            case 5:
                maxTrebuchet = 15;
                trebuchetTurnSpeed = 1.5f;
                trebuchetAttackSpeed = 0.1f;
                trebuchetDamage = 60;
                trebuchetLifetime = 60;
                break;
            default:
                break;
        }
        foreach (GameObject item in Trebuchets)
        {
            item.GetComponent<TrebuchetMove>().setTurnSpeed(trebuchetTurnSpeed);
            item.GetComponent<TrebuchetMove>().setTrebuchetLifetime(trebuchetLifetime);
            item.GetComponent<TrebuchetAttack>().setDamage(trebuchetDamage);
            item.GetComponent<TrebuchetAttack>().SetAttackSpeed(trebuchetAttackSpeed);
        }
    }
    private IEnumerator spawnTrebuchet()
    {
        spawnTrebuchetCooldown = true;
        var newTrebuchet = Instantiate(trebuchetPrefab, transform.position, Quaternion.identity);
        Trebuchets.Add(newTrebuchet);
        SetTrebuchetStats();
        yield return new WaitForSeconds(1);
        spawnTrebuchetCooldown = false;
    }
    public void removeFromTrebuchetList(GameObject treb)
    {
        Trebuchets.Remove(treb);
    }
    #endregion

    #region ShieldPowerUp
    public void SpawnShield()
    {
        var shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
        Shields.Add(shield);
    }

    private void SetShieldStats()
    {
        switch (shieldLevel)
        {
            case 1:
                maxShield = 1;
                shieldTurnSpeed = 10f;
                shieldDamage = 10;
                break;
            case 2:
                maxShield = 1;
                shieldTurnSpeed = 13f;
                shieldDamage = 20;
                break;
            case 3:
                maxShield = 1;
                shieldTurnSpeed = 18f;
                shieldDamage = 40;
                break;
            case 4:
                maxShield = 1;
                shieldTurnSpeed = 25f;
                shieldDamage = 50;
                break;
            case 5:
                maxShield = 1;
                shieldTurnSpeed = 50f;
                shieldDamage = 65;
                break;
            default:
                break;
        }
        foreach (GameObject item in Shields)
        {
            item.GetComponentInChildren<ShieldDamage>().setDamage(shieldDamage);
            item.GetComponent<ShieldHolderMove>().setShieldSpeed(shieldTurnSpeed);
        }
    }
    #endregion

    #region Player health Powerup
    public void SetPlayerHealthStats()
    {
        switch(PlayerHealthUpgradeLevel){
            case 1:
                transform.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(10);
                break;
            case 2:
                transform.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(20);
                break;
            case 3:
                transform.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(50);
                break;
            case 4:
                transform.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(100);
                break;
            case 5:
                transform.gameObject.GetComponent<PlayerHealth>().increaseMaxHealth(200);
                break;
        }
    }
    #endregion
    #region Player speed Powerup
    public void SetPlayerSpeedStats()
    {
        switch (PlayerSpeedUpgradeLevel)
        {
            case 1:
                transform.gameObject.GetComponent<Move>().IncreasePlayerSpeed(3);
                break;
            case 2:
                transform.gameObject.GetComponent<Move>().IncreasePlayerSpeed(6);
                break;
            case 3:
                transform.gameObject.GetComponent<Move>().IncreasePlayerSpeed(10);
                break;
            case 4:
                transform.gameObject.GetComponent<Move>().IncreasePlayerSpeed(20);
                break;
            case 5:
                transform.gameObject.GetComponent<Move>().IncreasePlayerSpeed(50);
                break;
        }
    }
    #endregion
    public enum PowerUpType
    {
        dog,
        trebuchet,
        shield,
        playerHealth,
        playerSpeed
    }
    public void UpgradePowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.dog:
                dogsEnabled = true;
                dogsLevel++;
                SetDogStats();
                break;
            case PowerUpType.trebuchet:
                TrebuchetEnabled = true;
                trebuchetLevel++;
                SetTrebuchetStats();
                break;
            case PowerUpType.shield:
                ShieldEnabled = true;
                shieldLevel++;
                SetShieldStats();
                break;
            case PowerUpType.playerHealth:
                PlayerHealthUpgradeLevel++;
                SetPlayerHealthStats();
                break;
            case PowerUpType.playerSpeed:
                PlayerSpeedUpgradeLevel++;
                SetPlayerSpeedStats();
                break;
            default:
                break;
        }
    }
}
