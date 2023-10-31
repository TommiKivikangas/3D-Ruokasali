using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{

    public float score;
    public float highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public static ScoreSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
        score = PlayerPrefs.GetFloat("score");
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        if (highScore < score)
        {
            PlayerPrefs.SetFloat("highScore", score);
        }
        score = PlayerPrefs.GetFloat("score");
        scoreText.text = "SCORE : " + score.ToString();
        highScoreText.text = "HIGHSCORE : " + highScore.ToString();
        
    }
}
