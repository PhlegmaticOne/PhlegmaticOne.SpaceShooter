using UnityEngine;
using UnityEngine.SceneManagement;

namespace AssemblyCSharp.Assets.Scripts.Levels
{
    public class LevelManager : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public static void LoadStartMenu()
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
