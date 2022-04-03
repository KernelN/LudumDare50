﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
   public class SpawnEnemyWind : MonoBehaviour
   {
        public GameObject objectToSpawn;

        public float windForceModifier;
        public float bonusPerSecond;

        public float secondsBetweenSpawn;
        public float elapsedTime = 0.0f;

        public float xA;
        public float xB;
        float y;

        void Update()
        {
            SpawnObjectA(true);
            SpawnObjectA(false);

            windForceModifier += bonusPerSecond * Time.deltaTime;
        }

        Vector2 GetSpawnPointA()
        {
            y = Random.Range(-0.20f,2.45f);

            return new Vector2(xA, y);
        }

        Vector2 GetSpawnPointB()
        {
            y = Random.Range(-0.20f, 2.45f);

            return new Vector2(xB, y);
        }

        void SpawnObjectA(bool spawnOnA)
        {
         
            elapsedTime += Time.deltaTime;

            if(elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;

                Vector2 spawnPosition;
                float spawnRotation;
                float windAngle;

                if (spawnOnA)
                {
                    spawnPosition = GetSpawnPointA();
                    spawnRotation = 180;
                    windAngle = 180;
                }
                else
                {
                    spawnPosition = GetSpawnPointB();
                    spawnRotation = 0;
                    windAngle = 0;
                }

                GameObject newEnemyWind = (GameObject)Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                newEnemyWind.transform.Rotate(0, spawnRotation, 0);
                newEnemyWind.GetComponent<WindController>().windAngle = windAngle;
                newEnemyWind.GetComponent<WindController>().windForce = windForceModifier;
            }
        }
   }
}

