using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universal.Highscore
{
    [Serializable]
    public class HighscoresTable { public List<Highscore> table; }

    public class ScoreManager : Singletons.MonoBehaviourSingleton<ScoreManager>
    {
        public List<Highscore> highscores { get { return highscoreTable.table; } }
        public int score
        {
            get { return currentScore.score; }
            set
            {
                //Set new score between min-max
                if (value < minScore)
                    value = minScore;
                if (value > maxScore)
                    value = maxScore;

                ///Update score
                currentScore.score = value;
                ScoreChanged?.Invoke();
            }
        }

        public Action ScoreChanged;

        [Header("Set Values")]
        [SerializeField] int minScore = 0;
        [SerializeField] int maxScore = 9999;

        [Header("Runtime Values")]
        [SerializeField] HighscoresTable highscoreTable;
        [SerializeField] Highscore currentScore;

        //Methods
        public void LoadHighscoresTable(HighscoresTable newTable)
        {
            highscoreTable = newTable;
        }
        public void AddScoreToHighscore(string name)
        {
            currentScore.name = name;
            highscoreTable.table.Add(currentScore);
            highscoreTable.table.Sort(HighscoreSorter.Compare);
            DeleteScore();
        }
        public void DeleteScore()
        {
            currentScore = new Highscore();
        }
    }
}