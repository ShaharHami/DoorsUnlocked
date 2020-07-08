using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class StartScreenManager : MonoBehaviour
    {
        public int sceneToLoad;
        public void StartGame()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
