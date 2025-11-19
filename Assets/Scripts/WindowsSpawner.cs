using System.Collections.Generic;
using UnityEngine;

public class WindowsSpawner : EnemySpawner
{
    [Header("Spawn Settings")]
    public float spawnIntervalSeconds = 2;
    public int maxEnemies = 10;
    public List<Vector3> spawnPositions = new List<Vector3>();

    float spawnTimer = 0;


    void Update()
    {
        if (spawnedEnemies.Count < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnIntervalSeconds)
            {
                int randomIndex = Random.Range(0, spawnPositions.Count);
                SpawnEnemy(spawnPositions[randomIndex]);
                spawnTimer = 0;
            }
        }
    }

}
