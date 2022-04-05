using UnityEngine;

namespace Anemos.Gameplay
{
    public class UIGameplayManager : MonoBehaviour
    {
        [System.Serializable]
        enum GameplayScreens {  inGame, milestone, pause, gameOver, resetGame}

        [Header("Set Values")]
        [SerializeField] GameplayManager manager;
        [SerializeField] GameObject inGameUI;
        [SerializeField] GameObject milestoneUI;
        [SerializeField] GameObject pauseUI;
        [SerializeField] GameObject gameOverUI;

        [Header("Runtime Values")]
        [SerializeField] GameplayScreens currentState = GameplayScreens.inGame;

        //Unity Events
        private void Start()
        {
            //If manager wasn't asigned, get it
            if (manager == null)
            {
                manager = GameplayManager.Get();
            }

            //Link action
            manager.MilestoneReached += OnMilestoneReached;
            manager.PlayerLost += OnPlayerLost;
            manager.GamePaused += OnPause;
        }
        private void OnDestroy()
        {
            //Unlink action
            manager.PlayerLost -= OnPlayerLost;
            manager.PlayerLost -= OnPlayerLost;
            manager.GamePaused -= OnPause;
        }

        //Methods
        public void SetPause(bool pause)
        {
            GameManager.Get().SetPause(pause);

            currentState = pause ? GameplayScreens.pause : GameplayScreens.inGame;
            SwitchUIStage();
        }
        void SetMilestone()
        {
            GameManager.Get().SetPause(true);

            currentState = GameplayScreens.milestone;
            SwitchUIStage();
        }
        void SetGameOver()
        {
            GameManager.Get().SetPause(true);

            currentState = GameplayScreens.gameOver;
            SwitchUIStage();
        }
        void SwitchUIStage()
        {
            switch (currentState)
            {
                case GameplayScreens.inGame:
                    pauseUI.SetActive(false);
                    milestoneUI.SetActive(false);
                    inGameUI.SetActive(true);
                    break;
                case GameplayScreens.milestone:
                    inGameUI.SetActive(false);
                    milestoneUI.SetActive(true);
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

        //Event receivers
        void OnMilestoneReached()
        {
            SetMilestone();
        }
        void OnPause()
        {
            SetPause(manager.publicPause);
        }
        void OnPlayerLost()
        {
            SetGameOver();
        }
    }
}