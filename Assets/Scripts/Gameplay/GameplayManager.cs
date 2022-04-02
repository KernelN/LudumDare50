using System;
using UnityEngine;
using Universal.Singletons;

namespace NAMESPACENAME.Gameplay
{
    public class GameplayManager : MonoBehaviourSingletonInScene<GameplayManager>
    {
        [Header("Set Values")]
        [SerializeField] Transform pot;
        [SerializeField] float loseHeight;

        [Header("Runtime Values")]
        [SerializeField] float timer;
        [SerializeField] bool gameOver;

        public Action PotFalled;

        //Unity Events
        private void Start()
        {
            if (pot == null)
            {
                pot = GameObject.FindGameObjectWithTag("Pot").transform;
            }
        }
        private void Update()
        {
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
                GameOver();
            }
        }
        void UpdateTimer()
        {
            //Advance Timer
            timer += Time.deltaTime;

            //if timer bigger than 1, add 1 to score and reset timer
            if (timer > 1)
            {
                timer -= 1;
                Universal.Highscore.ScoreManager.Get().score += 1;
            }
        }
        void GameOver()
        {
            gameOver = true;
            PotFalled?.Invoke();
        }
    }
}