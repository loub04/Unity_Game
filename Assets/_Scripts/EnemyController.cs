using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject crabEnemyPrefab;
    [SerializeField]
    private GameObject shroomEnemyPrefab;
    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private int nextEnemySpawn;
    [SerializeField]
    private float shroomSpawnChance = 0.05f;
    [SerializeField]
    private float multiplier = 1.0f;
    [SerializeField]
    private float increaseMultiplier = 0.01f;
    [SerializeField]
    private Transform spawnTopLeft, spawnTopRight, spawnBottomLeft, spawnBottomRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCount = GameManager.Instance.GetEnemyCount();
        for(int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
    
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(crabEnemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.OnDie += SpawnEnemy;
            enemy.IncreaseSpeed(multiplier);
            multiplier += increaseMultiplier;
        }
            
        if(GameManager.Instance.GetEnemyKilled() >= nextEnemySpawn && Random.value < shroomSpawnChance)
        {
            Vector3 shroomPosition = SelectRandomPosition();
            GameObject shroomObject = Instantiate(shroomEnemyPrefab, shroomPosition, Quaternion.identity);
            Enemy shroom = shroomObject.GetComponent<Enemy>();
            if(shroom != null)
            {
                shroom.OnDie += SpawnEnemy;
                shroom.DecreaseSpeed(0.8f);
            }
        }
    }


    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;
        int randomValue = Random.Range(0, 4);
        switch(randomValue)
        {
            case 0:
                selectedTransform = spawnTopLeft;
                break;
            case 1:
                selectedTransform = spawnTopRight;
                break;
            case 2:
                selectedTransform = spawnBottomLeft;
                break;
            case 3:
                selectedTransform = spawnBottomRight;
                break;
            default:
                selectedTransform = spawnBottomLeft;
                break;
        }
        return selectedTransform.position + (Vector3)Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
