using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    public class PlayerWindController : MonoBehaviour
    {

        [Header("Set Values")]
        [SerializeField] Transform windEmpty;
        [SerializeField] GameObject windPrefab;
        [SerializeField] float maxWindHeight;
        [SerializeField] int maxWindsInGame;
        
        [Header("Runtime Values")]
        [SerializeField] List<Transform> winds;
        [SerializeField] Vector2 windStart;
        [SerializeField] Vector2 windDirection;

        //Unity Events
        private void Update()
        {
            //Check TimeScale/Pause before asking for input -THIS IS VERY BERRETA, CHANGE LATER
            if (Time.deltaTime == 0) return;
            
            if (Input.GetMouseButtonDown(0))
            {
                AddWindStartPos();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                AddWindDirection();
            }
        }

        //Methods
        void AddWindStartPos()
        {
            //Get Start of Drag mouse position
            windStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(windStart.y > maxWindHeight)
            {
                windStart.y = maxWindHeight;
            }
            //Debug.Log("Start Drag - " + windStart);
        }
        void AddWindDirection()
        {
            //Get End of Drag mouse position
            windDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (windDirection.y > maxWindHeight)
            {
                windDirection.y = maxWindHeight;
            }
            //Debug.Log("End Drag - " + windDirection);

            //Calculate Direction
            windDirection -= windStart;

            //Call Wind Spawn
            SpawnWind();
        }        
        void SpawnWind()
        {
            //Instantiate Wind
            Transform wind = Instantiate(windPrefab, windEmpty).transform;
            
            //Set position & direction
            wind.position = windStart;
            wind.right = windDirection;

            //Set The Name of the Wind (trademark)
            wind.gameObject.name = GetWindName();

            //Add to list
            winds.Add(wind);

            //Remove oldest wind if count is bigger than max
            if (winds.Count > maxWindsInGame)
            {
                wind = winds[0];
                winds.RemoveAt(0);
                Destroy(wind.gameObject);
            }
        }
        string GetWindName()
        {
            string windName = "N" + (winds.Count + 1);

            if (windDirection.y > 0)
            {
                windName += " North";
            }
            else if (windDirection.y < 0)
            {
                windName += " South";
            }

            if (windDirection.x > 0)
            {
                windName += " East";
            }
            else if (windDirection.x < 0)
            {
                windName += " West";
            }

            windName += " Wind ";

            return windName;
        }
    }
}