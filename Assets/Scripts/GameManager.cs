using UnityEngine;
using Universal.SceneManaging;
using Universal.Singletons;

namespace NAMESPACENAME
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public System.Action SceneChanged;

        public Scenes targetScene { get { return currentScene; } }
        [SerializeField] Scenes currentScene;

        //Unity Events
        private void Start()
        {
            currentScene = SceneLoader.GetCurrentScene();
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
        public void LoadScene(Scenes sceneToLoad)
        {
            SetPause(false); //reset time in case game was paused

            //Update "currentScene" and load
            currentScene = sceneToLoad;
            SceneLoader.LoadScene(currentScene);
            SceneChanged?.Invoke();
        }
        public void QuitGame()
        {
            //if (currentScene == Scenes.idle)
            //{
            //    player?.SaveLogOutDate();
            //}
            //player?.SaveData();
            Application.Quit();
        }
    }
}