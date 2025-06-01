using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{public static ScoreManager GetInstance()
    {
        if(instance == null)
        {
            GameObject gameObject = new GameObject();
        
            instance= gameObject.AddComponent<ScoreManager>();

            instance.Init();

            DontDestroyOnLoad(gameObject);
        }
        return instance;
    }

    private static ScoreManager instance;
    private int currentScore = 0;

    public event Action<int> OnScoreChanged;


    private void Init()
    {
        //if (PlayerPrefs.GetInt("CurrentScore", currentScore) != 0)
        //{
        //    currentScore = PlayerPrefs.GetInt("CurrentScore", currentScore);
        //}
    }


    public int GetScore()
    {
        return currentScore;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        BroadcastScore();
    }

    public void SetScore(int score)
    {
        currentScore = score;
        BroadcastScore();
    }

    private void BroadcastScore()
    {
        OnScoreChanged?.Invoke(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        BroadcastScore();
    }
}
