using Jaba.Route.Helpers;
using Jaba.Route.Triggers;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jaba.Route.UI
{
    public class Score : MonoBehaviour
    {
        #region Variables

        private Text scoreLabel;
        public int score { get; private set; } = 0;

        #endregion

        #region BuiltIn Methods

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

        #endregion

        #region Custom Methods

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

        #endregion

    }
}