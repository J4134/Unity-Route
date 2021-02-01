using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void RestartScene()
    {
        ProgressKeeper.UpdateGamesPlayedCount();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
