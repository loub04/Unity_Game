using UnityEngine;

public class PotionSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject potionPrefab;
    private int lastSpawnedAt = 0;
    private int enemyKilled = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnPotion()
    {
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject potionObject = Instantiate(potionPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 SelectRandomPosition()
    {
        float x = Random.Range(-9f, 10f);
        float y = Random.Range(-5f, 4f);

        return  (Vector3) new Vector2 (x, y);
    }

    private void OnEnable()
    {
        Enemy.OnAnyDie += HandleEnemyKilled;
    }

    private void OnDisable()
    {
        Enemy.OnAnyDie -= HandleEnemyKilled;
    }

    private void HandleEnemyKilled()
    {
        enemyKilled = GameManager.Instance.GetEnemyKilled();
        if(enemyKilled > 0 && enemyKilled % 5 == 0 && enemyKilled != lastSpawnedAt)
        {
            lastSpawnedAt = enemyKilled;
            SpawnPotion();
        }
    }

}
