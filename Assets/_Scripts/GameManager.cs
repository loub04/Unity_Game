using System;
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

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public int GetEnemyKilled()
    {
        return enemyKilled;
    }

    public int GetScore()
    {
        return score;
    }

    internal void increaseKilled()
    {
        enemyKilled++;
    }
}