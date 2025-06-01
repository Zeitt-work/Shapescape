using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    public int _score;

    private void Awake()
    {
    
         
      
    }


    void Start()
    {

        ScoreManager.GetInstance().OnScoreChanged += UpdateScore;
        _currentScoreText.text = ScoreManager.GetInstance().GetScore().ToString();

        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        UpdateHighScore();
    }



    void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore(int score)
    {
        _score = score;

        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }

}