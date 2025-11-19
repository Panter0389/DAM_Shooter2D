using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public EnemyBase enemyPrefab;
    protected List<EnemyBase> spawnedEnemies = new List<EnemyBase>();

    public void EnemyDie(EnemyBase enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
        EnemyBase newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        newEnemy.Initialize(this);
        spawnedEnemies.Add(newEnemy);
    }
}
