using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jaba.Route.Helpers
{
    public class SceneController : MonoBehaviour
    {
        public void RestartScene()
        {
            ProgressKeeper.UpdateGamesPlayedCount();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}