using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    public class UIGameplayManager : MonoBehaviour
    {
        [System.Serializable]
        enum GameplayScreens {  inGame, pause, gameOver, resetGame}

        [Header("Set Values")]
        [SerializeField] GameObject inGameUI;
        [SerializeField] GameObject pauseUI;
        [SerializeField] GameObject gameOverUI;

        [Header("Runtime Values")]
        [SerializeField] GameplayScreens currentState = GameplayScreens.inGame;

        //Unity Events

        //Methods
        public void SetPause(bool pause)
        {
            GameManager.Get().SetPause(pause);

            currentState = pause ? GameplayScreens.pause : GameplayScreens.inGame;
            SwitchUIStage();
        }
        void SwitchUIStage()
        {
            switch (currentState)
            {
                case GameplayScreens.inGame:
                    pauseUI.SetActive(false);
                    inGameUI.SetActive(true);
                    break;
                case GameplayScreens.pause:
                    inGameUI.SetActive(false);
                    pauseUI.SetActive(true);
                    break;
                case GameplayScreens.gameOver:
                    inGameUI.SetActive(false);
                    gameOverUI.SetActive(true);
                    break;
                case GameplayScreens.resetGame:
                    gameOverUI.SetActive(false);
                    inGameUI.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}