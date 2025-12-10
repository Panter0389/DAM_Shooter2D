using System.Collections.Generic;
using UnityEngine;

public class RunnerSpawner : EnemySpawner
{
    [Header("Spawn Settings")]
    public EnemyBase civilPrefab;
    public float spawnIntervalSeconds = 2;
    public List<Vector3> spawnPositions = new List<Vector3>();
    public int civilSpawnRate = 3;

    float spawnTimer = 0;
    int civilSpawnRateCounter = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnIntervalSeconds)
        {
            civilSpawnRateCounter++;

            int spawnIndex = Random.Range(0, spawnPositions.Count);
            Vector3 position = spawnPositions[spawnIndex];

            if (civilSpawnRateCounter >= civilSpawnRate)
            {
                SpawnEnemy(position, civilPrefab);
                civilSpawnRateCounter = 0;
            }
            else
            {
                SpawnEnemy(position, enemyPrefab);
            }

            spawnTimer = 0;
        }

    }
}
