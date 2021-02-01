using UnityEngine;

namespace Jaba.Route.Helpers
{
    public static class ProgressKeeper
    {
        public static void UpdateGamesPlayedCount()
        {
            PlayerPrefs.SetInt("gamesPlayed", PlayerPrefs.GetInt("gamesPlayed") + 1);
        }

        public static void UpdateMaxScore(int newMaxScore)
        {
            if (newMaxScore > PlayerPrefs.GetInt("maxScore"))
            {
                PlayerPrefs.SetInt("maxScore", newMaxScore);
            }
        }

    }
}