using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllerMain : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject spawnPoint;
    public int numberOfZombies;
    public List<GameObject> zombies;
    public GameObject HealthText;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void spawnZombies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var radians = 2 * MathF.PI / amount * i;
            var vertical = MathF.Sin(radians);
            var horizontal = MathF.Cos(radians);
            var spawnDir = new Vector3(horizontal, 0, vertical);
            var spawnPos = spawnPoint.transform.position + spawnDir * 10; // Radius is just the distance away from the point

            var enemy = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
            enemy.transform.Translate(new Vector3(0, enemy.transform.localScale.y / 2, 0));
            zombies.Add(enemy);


            //Instantiate(zombiePrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnZombies(numberOfZombies);
        }
    }

}
