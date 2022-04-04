using System;
using UnityEngine;
using Universal.Singletons;

namespace Anemos.Background
{
    public class BackgroundManager : MonoBehaviourSingletonInScene<BackgroundManager>
    {
        [Header("Set Values")]
        [SerializeField] TimedBackground[] backgrounds;
        [SerializeField] GameObject background;

        [Header("Runtime Values")]
        [SerializeField] int currentIndex;
        [SerializeField] int currentHour;

        //Unity Events
        private void Start()
        {
            if (background == null)
            {
                background = GameObject.FindGameObjectWithTag("Background");
            }

            GetCurrentBackground();
            SetCurrentBackground();
        }

        //Methods
        void GetCurrentBackground()
        {
            currentHour = DateTime.Now.Hour;

            for (int i = 0; i < backgrounds.Length; i++)
            {
                currentIndex = i;
                foreach (var hourRange in backgrounds[i].hours)
                {
                    if (CurrentHourIsInRange(hourRange.publicStartHour, hourRange.publicEndHour))
                    {
                        return;
                    }
                }
                
            }
        }
        void SetCurrentBackground()
        {
            //Create new background
            GameObject newBackground = Instantiate(backgrounds[currentIndex].prefab);
            
            //Set in same transform as old one
            newBackground.transform.position = background.transform.position;
            newBackground.transform.rotation = background.transform.rotation;
            newBackground.transform.localScale = background.transform.localScale;

            //Transfer new background to background var
            Destroy(background);
            background = newBackground;
        }
        bool CurrentHourIsInRange(float startHour, float endHour)
        {
            return currentHour >= startHour && currentHour <= endHour;
        }
    }
}