using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject preGameUI;

    [SerializeField]
    private GameObject inGameUI;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Text preGameLabel;

    [SerializeField]
    private Text gameOverLabel;

    private void OnEnable()
    {
        PlayerController.OnGameStarted += ShowInGameUI;
        PlayerController.OnGameStopped += ShowGameOverUI;
    }
    private void OnDisable()
    {
        PlayerController.OnGameStarted -= ShowInGameUI;
        PlayerController.OnGameStopped -= ShowGameOverUI;
    }

    private void Start()
    {
        preGameUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);

        preGameLabel.text = "best score: " + PlayerPrefs.GetInt("maxScore") + "\n" + "games played: " + PlayerPrefs.GetInt("gamesPlayed");
    }

    private void ShowInGameUI()
    {
        inGameUI.SetActive(true);
        preGameUI.SetActive(false);
    }

    private void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);

        gameOverLabel.text = "your score: " + scoreLabel.text + "\n" + "best score: " + PlayerPrefs.GetInt("maxScore");
    }

  
}
