using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
   public class SpawnEnemyWind : MonoBehaviour
   {
        public GameObject objectToSpawn;

        public float windForceModifier;
        public float bonusPerSecond;

        public float spawnTimer;
        public float spawnTimerDecrease;
        public float minSpawnTime;

        float spawnResetValue;

        public float xA;
        public float xB;
        float y;

        int spawnOne;

        void Start()
        {
            spawnResetValue = spawnTimer;
        }

        void Update()
        {           
            SpawnEnemy();
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

        void SpawnObject(bool spawnOnA)
        {

            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
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

                spawnResetValue -= spawnTimerDecrease;
                spawnTimer = spawnResetValue;

                if(spawnTimer < minSpawnTime)
                {
                    spawnTimer = minSpawnTime + 2f;
                }
            }
        }

        void SpawnEnemy()
        {
            spawnOne = Random.Range(0, 10);
            if (spawnOne <= 5)
            {
                SpawnObject(true);
            }          
            else
            {
                SpawnObject(false);
            }

            windForceModifier += bonusPerSecond * Time.deltaTime;
        }
    }
}

