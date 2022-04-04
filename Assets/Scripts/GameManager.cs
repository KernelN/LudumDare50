using UnityEngine;
using Universal.SceneManaging;
using Universal.Singletons;

namespace NAMESPACENAME
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public System.Action SceneChanged;

        [SerializeField] Scenes currentScene;
        [SerializeField] PlayerData playerData;

        public Scenes targetScene { get { return currentScene; } }

        //Unity Events
        private void Start()
        {
            currentScene = SceneLoader.GetCurrentScene();
            LoadAll();
        }
        private void OnDestroy()
        {
            if (GameManager.Get() == this)
            {
                QuitGame();
            }
        }

        //Methods
        public void SetPause(bool pause)
        {
            Time.timeScale = pause ? 0 : 1;
        }
        public void LoadScene(Scenes sceneToLoad, int level)
        {
            SetPause(false); //reset time in case game was paused

            //Update "currentScene" and load
            currentScene = sceneToLoad;
            SceneLoader.LoadScene(currentScene, level);
            SceneChanged?.Invoke();
        }
        public void QuitGame()
        {
            SaveAll();
            Application.Quit();
        }
        void SaveAll()
        {
            playerData.SaveData();
        }
        void LoadAll()
        {
            if (playerData == null)
            {
                playerData = new PlayerData();
            }

            playerData.LoadData();
        }
    }
}