using UnityEngine;
using TMPro;

namespace Universal.Highscore
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI highscoreText;
        [SerializeField] TextMeshProUGUI[] scoreTexts;
        [SerializeField] TMP_InputField playerName;
        ScoreManager highscoreManager;

        //Unity Events
        private void Start()
        {
            //Get Manager and link actions
            highscoreManager = ScoreManager.Get();
            highscoreManager.ScoreChanged += OnScoreChanged;
            OnScoreChanged();
        }

        //Methods
        public void AddScoreToHighscore()
        {
            if (playerName.text == "") return;

            highscoreManager.AddScoreToHighscore(playerName.text);
        }
        public void DeleteCurrentScore()
        {
            highscoreManager.DeleteScore();
        }
        void UpdateNextHighscoreText()
        {
            //get the score higher than the current
            int higherScorePos = GetScorePosition();

            if (higherScorePos == -1)
            {
                highscoreText.text = "There is no highscore, you're the first!";
                return;
            }

            Highscore higherScore = ScoreManager.Get().highscores[higherScorePos];
            highscoreText.text = "#" + (higherScorePos + 1) + " " + higherScore.name + " - " + higherScore.score;
        }
        int GetScorePosition()
        {
            //Get Highscores
            System.Collections.Generic.List<Highscore> highscores;
            highscores = ScoreManager.Get().highscores;

            //If there is no list, return false
            if (highscores.Count < 1) return -1;

            highscores.Sort(HighscoreSorter.Compare); //sort list

            //Return position (position 0 counts as #1)
            for (int i = 1; i < highscores.Count; i++)
            {
                //Compare highscore with score, if score is bigger, return previous highscore
                if (highscores[i].score >= highscoreManager.score) continue;
                return i - 1;
            }

            //There was no score lower than this one, so return #lastPos
            return highscores.Count - 1;
        }

        //Event Receivers
        void OnScoreChanged()
        {
            if (scoreTexts.Length < 1) return;
            foreach (var text in scoreTexts)
            {
                text.text = highscoreManager.score.ToString("D4");
            }
            UpdateNextHighscoreText();
        }
    }
}