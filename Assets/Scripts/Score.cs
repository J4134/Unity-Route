using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score { get; private set; } = 0;
    private Text scoreLabel;

    private void OnEnable()
    {
        SpawnTrigger.OnSpawnTriggerEntered += AddScore;
        PlayerController.OnGameStopped += SaveScore;
    }

    private void OnDisable()
    {
        SpawnTrigger.OnSpawnTriggerEntered -= AddScore;
        PlayerController.OnGameStopped -= SaveScore;
    }

    private void Start()
    {
        score = 0;
        scoreLabel = GetComponent<Text>();
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreLabel.text = Convert.ToString(score);
    }

    private void AddScore()
    {
        score++;
        UpdateScore();
    }

    private void SaveScore() => ProgressKeeper.UpdateMaxScore(score);

}
