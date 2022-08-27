using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    public Wave[] waveSetup;
    public GameObject ZombiePrefab;
    public GameObject TrollPrefab;
    public GameObject RatPrefab;
    public GameObject player;
    public float waveCooldown;
    public GameObject HealthText;
    public Camera cam;

    public enum myEnum // your custom enumeration
    {
        Zombie,
        Troll,
        Rat
    };
    [Serializable]
    public struct EnemiesForWave
    {
        public myEnum name;
        public int numberOfEnemies;
    }
    [Serializable]
    public struct Wave
    {
        public int waveNumber;
        public EnemiesForWave[] enemies;
        public int timeToNextWave;
    }

    // Update is called once per frame
    void Start()
    {
        cam = Camera.main;
        StartCoroutine(Cooldown());
    }

    private void spawnEnemy(myEnum name, int numberOfEnemies)
    {
        GameObject selectedEnemyPrefab = null;
        switch (name)
        {
            case myEnum.Zombie:
                selectedEnemyPrefab = ZombiePrefab;
                break;
            case myEnum.Troll:
                selectedEnemyPrefab = TrollPrefab;
                break;
            case myEnum.Rat:
                selectedEnemyPrefab = RatPrefab;
                break;
            default:
                break;
        }
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            Vector3 spawnPos = UnityEngine.Random.insideUnitCircle * 5;


            Instantiate(selectedEnemyPrefab, new Vector3(cam.transform.position.x + UnityEngine.Random.Range(-width, width), 3, cam.transform.position.z + height + UnityEngine.Random.Range(10, 30)), Quaternion.identity);
        }
    }

    private IEnumerator Cooldown()
    {

        for (int i = 0; i < waveSetup.Length; i++)
        {
            for (int j = 0; j < waveSetup[i].enemies.Length; j++)
            {
                spawnEnemy(waveSetup[i].enemies[j].name, waveSetup[i].enemies[j].numberOfEnemies);
            }

            yield return new WaitForSeconds(waveSetup[i].timeToNextWave);

        }

    }

}
