using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Universal.Highscore
{
    public class UIHighscoreTable : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI highscoreTexts;
        const string divider = " - ";

        //Unity Events
        private void Start()
        {
            //Get Highscores
            List<Highscore> highscores = ScoreManager.Get().highscores;

            //Checka list is not empty
            if(highscores.Count < 1)
            {
                highscoreTexts.text = "There are no scores yet!";
                return;
            }

            //Set list & clear text
            highscores.Sort(HighscoreSorter.Compare);
            highscoreTexts.text = "";

            //Build Table
            for (int i = 0; i < highscores.Count; i++)
            {
                AddScoreToTable(highscores[i], i + 1);
            }
        }

        //Methods
        void AddScoreToTable(Highscore data, int number)
        {
            string name = data.name;
            string score = data.score.ToString();
            string tablePos = number.ToString();

            if (number != 1)
            {
                highscoreTexts.text += "\n";
            }

            highscoreTexts.text += "#" + tablePos + " " + name + divider + score;
        }
    }
}