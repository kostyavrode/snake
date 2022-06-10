using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;
    private int currentScore;
    private void OnEnable()
    {
        if(!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
        Snake.OnPlayerDeath += CheckScore;
    }
    private void OnDisable()
    {
        Snake.OnPlayerDeath -= CheckScore;
    }
    private void Update()
    {
        if (Snake.isPlayerAlive)
        {
            currentScore += 1;
            scoreText.text = currentScore.ToString();
        }
    }
    private void CheckScore()
    {
        if (PlayerPrefs.GetInt("BestScore") < currentScore)
            PlayerPrefs.SetInt("BestScore", currentScore);
        bestScoreText.text += PlayerPrefs.GetInt("BestScore").ToString();
    }
}
