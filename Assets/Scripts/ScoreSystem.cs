using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public float score;
    public float highScore;

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
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {


        if (PlayerPrefs.GetFloat("highScore") < score)
        {
            PlayerPrefs.SetFloat("highScore", score);
        }
    }
}
