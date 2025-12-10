using System.Collections.Generic;
using UnityEngine;

public class WindowsSpawner : EnemySpawner
{
    [Header("Spawn Settings")]
    public float spawnIntervalSeconds = 2;
    public int maxEnemies = 10;
    public List<Vector3> spawnPositions = new List<Vector3>();
    List<int> occupiedSpawnPositionsIndex = new List<int>();

    float spawnTimer = 0;


    public override void EnemyDie(EnemyBase enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            Vector3 enemyPosition = enemy.transform.position;

            for (int i = 0; i < spawnPositions.Count; i++)
            {
                if (Vector2.Distance(spawnPositions[i],enemyPosition) < 0.1f)
                {
                    if (occupiedSpawnPositionsIndex.Contains(i))
                    {
                        occupiedSpawnPositionsIndex.Remove(i);
                        break;
                    }
                }
            }

            spawnedEnemies.Remove(enemy);
        }
    }

    void Update()
    {
        if (spawnedEnemies.Count < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnIntervalSeconds)
            {
                if (occupiedSpawnPositionsIndex.Count >= spawnPositions.Count)
                {
                    spawnTimer = 0;
                    return;
                }

                int randomIndex = 0;
                do
                {
                    randomIndex = Random.Range(0, spawnPositions.Count);
                }
                while (occupiedSpawnPositionsIndex.Contains(randomIndex));


                SpawnEnemy(spawnPositions[randomIndex]);
                spawnTimer = 0;

                occupiedSpawnPositionsIndex.Add(randomIndex);
            }
        }
    }

}
