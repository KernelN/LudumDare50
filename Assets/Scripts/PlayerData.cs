using Universal.FileManaging;
using Universal.Highscore;

namespace Anemos
{
    [System.Serializable]
    public class PlayerData
    {
        public int lastLevelUnlocked = 1;
        HighscoresTable highScores;

        public void LoadData()
        {
            string dataPath = UnityEngine.Application.persistentDataPath + "playerData.bin";

            PlayerData savedData = FileManager<PlayerData>.LoadDataFromFile(dataPath);

            //If there was not any data saved, stop load
            if (savedData == null) return;

            if (savedData.lastLevelUnlocked > 1)
            {
            lastLevelUnlocked = savedData.lastLevelUnlocked;
            }
            if (savedData.highScores.table != null)
            {
                ScoreManager.Get().LoadHighscoresTable(savedData.highScores);
            }
        }
        public void SaveData()
        {
            string dataPath = UnityEngine.Application.persistentDataPath + "playerData.bin";

            if (highScores == null)
            {
                highScores = new HighscoresTable();
            }
            highScores.table = ScoreManager.Get().highscores;
            FileManager<PlayerData>.SaveDataToFile(this, dataPath);
        }
    }
}