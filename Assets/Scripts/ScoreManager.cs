using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static int score = 0;
    public static int highScore = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        highScore = LoadHighScore();
    }

    void Update(){ 
        if (score > highScore)
        {
            PlayerPrefs.SetInt("KnifeHitHighScore", score);
            highScore = score;
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("KnifeHitHighScore", 0);
    }
}
