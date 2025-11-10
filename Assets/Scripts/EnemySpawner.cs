
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Camera mainCamera;

    [Header("Spawn Settings")]
    public EnemyBase enemyPrefab;
    public float spawnIntervalSeconds = 2;
    public int maxEnemies = 10;

    float spawnTimer = 0;
    Vector2 xSpawnRange;
    Vector2 ySpawnRange;

    List<EnemyBase> spawnedEnemies = new List<EnemyBase>();
    
    void Start()
    {

        Vector3 leftBotttomCameraWorldPosition = mainCamera.ViewportToWorldPoint(Vector2.zero);
        Vector3 rightUpperCameraWorldPosition = mainCamera.ViewportToWorldPoint(Vector2.one);

        float xMin;
        float xMax;
        float yMin;
        float yMax;

        xMin = leftBotttomCameraWorldPosition.x;
        xMax = rightUpperCameraWorldPosition.x;

        yMin = leftBotttomCameraWorldPosition.y;
        yMax = rightUpperCameraWorldPosition.y;

        xSpawnRange = new Vector2(xMin, xMax);
        ySpawnRange = new Vector2(yMin, yMax);

        
    }

    public void EnemyDie(EnemyBase enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
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
                float xSpawnPosition = Random.Range(xSpawnRange.x, xSpawnRange.y);
                float ySpawnPosition = Random.Range(ySpawnRange.x, ySpawnRange.y);
                Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition, -1);
                EnemyBase newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
                
                newEnemy.Initialize(this);

                spawnedEnemies.Add(newEnemy);

                spawnTimer = 0;
            }
        }
    }
}
