using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int enemyCount = 5;
    [SerializeField]
    private Transform spawnTopLeft, spawnTopRight, spawnBottomLeft, spawnBottomRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.OnDie += SpawnEnemy;
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
