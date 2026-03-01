using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int enemyKilled = 0;
    [SerializeField]
    private int enemyCount = 5;

    void Awake()
    {
        Instance = this;
    }

    public int getEnemyCount()
    {
        return enemyCount;
    }
}