using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private int points = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int levelBase = 100;

    private float waitToSpawn = 0;
    [SerializeField] private float chargeTime = 5f;

    [SerializeField] private int enemiesQtd = 0;

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    public void PointsToGive(int points)
    {
        this.points += points;

        if (this.points > levelBase * level)
        {
            level++;
        }
    }

    public void ReduceEnemiesQtd()
    {
        enemiesQtd--;
    }

    private void SpawnEnemies()
    {
        if (waitToSpawn > 0)
        {
            waitToSpawn -= Time.deltaTime;
        }
        if (waitToSpawn <= 0)
        {
            int qtdDifficulty = level * 4;

            while (enemiesQtd < qtdDifficulty)
            {
                GameObject enemyCreated;
                float chance = Random.Range(0, level);

                if (chance > 4f)
                {
                    enemyCreated = enemies[1];
                }
                else
                {
                    enemyCreated = enemies[0];
                }

                Vector3 spawnOffset = new Vector3(Random.Range(-8, 8), Random.Range(7, 12), transform.position.z);

                Instantiate(enemyCreated, spawnOffset, transform.rotation);
                enemiesQtd++;
                waitToSpawn = chargeTime;

            }
        }
    }
}
