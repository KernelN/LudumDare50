using UnityEngine;

namespace Anemos.Menu
{
    public class UIMenu : MonoBehaviour
    {
        [Tooltip("Order them by difficulty (same as player levels)")]
        [SerializeField] GameObject[] levelButtons;

        //Unity Events
        private void Start()
        {
            //Get player level
            int playerLevel = GameManager.Get().playerData.lastLevelUnlocked;
            
            //Activate the unlocked levels
            for (int i = 0; i < playerLevel; i++)
            {
                levelButtons[i].SetActive(true);
            }
        }
    }
}