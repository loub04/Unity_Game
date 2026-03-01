using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString() + " POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.Instance.GetScore();
        scoreText.text = "SCORE: " + score.ToString() + " POINTS";
    }
}
