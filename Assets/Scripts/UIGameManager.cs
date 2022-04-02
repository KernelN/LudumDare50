using UnityEngine;

namespace ZombieStocks
{
    public class UIGameManager : MonoBehaviour
    {
        GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.Get();
        }

        public void LoadScene(Universal.SceneManaging.SceneGetter sceneGetter)
        {
            gameManager.LoadScene(sceneGetter.scene);
        }
        public void QuitGame()
        {
            gameManager.QuitGame();
        }
    }
}