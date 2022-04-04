using System;
using UnityEngine;
using Universal.Singletons;

namespace Anemos.Gameplay
{
    public class GameplayManager : MonoBehaviourSingletonInScene<GameplayManager>
    {
        [Header("Set Values")]
        [SerializeField] Transform pot;
        [SerializeField] float loseHeight;
        [SerializeField] float sendGameOverTimer;
        [SerializeField] float timeForNextLvl;
        [SerializeField] int level;

        [Header("Runtime Values")]
        [SerializeField] float timer;
        [SerializeField] bool pause = false;
        [SerializeField] bool gameOver;

        public Action PlayerLost;
        public Action PotFalled;
        public Action GamePaused;

        public bool publicPause { get { return pause; } }

        //Unity Events
        private void Start()
        {
            if (pot == null)
            {
                pot = GameObject.FindGameObjectWithTag("Pot").transform;
            }

            Universal.Highscore.ScoreManager.Get().score = 0;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause = !pause;
                GameManager.Get().SetPause(pause);
                GamePaused.Invoke();
            }

            if (Time.timeScale == 0) return;
            if (gameOver) return;

            CheckPotHeight();

            UpdateTimer();            

#if UNITY_EDITOR
            DrawGameOverHeight();
#endif
        }

        //Methods
        const float lineRadius = 50;
        void DrawGameOverHeight()
        {
            Vector2 lineStart = new Vector2(-lineRadius, loseHeight);
            Vector2 lineEnd = new Vector2(lineRadius, loseHeight);
            Debug.DrawLine(lineStart, lineEnd);
        }
        void CheckPotHeight()
        {
            if (pot.position.y < loseHeight)
            {
                PotFalled.Invoke();
                gameOver = true;
                Invoke("GameOver", sendGameOverTimer);
            }
        }
        void UpdateTimer()
        {
            //Advance Timer
            timer += Time.deltaTime;

            //if timer bigger than 1, add 1 to score and reset timer
            Universal.Highscore.ScoreManager.Get().score = (int)timer * level;
        }
        void GameOver()
        {
            PlayerData playerData = GameManager.Get().playerData;
            if (timer > timeForNextLvl && level == playerData.lastLevelUnlocked)
            {
                playerData.lastLevelUnlocked++;
            }

            PlayerLost?.Invoke();
        }
    }
}