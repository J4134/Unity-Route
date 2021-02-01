using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProgressKeeper
{
    public static void UpdateGamesPlayedCount()
    {
        PlayerPrefs.SetInt("gamesPlayed", (PlayerPrefs.GetInt("gamesPlayed") + 1));
    }

    public static void UpdateMaxScore(int newMaxScore)
    {
        if (newMaxScore > PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", newMaxScore);
        }
    }
    
}
