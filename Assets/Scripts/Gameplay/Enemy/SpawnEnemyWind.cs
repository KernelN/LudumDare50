using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
   public class SpawnEnemyWind : MonoBehaviour
    {
        public GameObject objectToSpawnA;
        public GameObject objectToSpawnB;

        public float secondsBetweenSpawn;
        public float elapsedTime = 0.0f;

        public float xA;
        public float xB;
        float y;  

        void Update()
        {
            SpawnObjectA();
            SpawnObjectB();
        }

        Vector2 GetSpawnPointA()
        {
            y = Random.Range(-0.20f,2.45f);
            Debug.Log(y);

            return new Vector2(xA, y);
        }

        Vector2 GetSpawnPointB()
        {
            y = Random.Range(-0.20f, 2.45f);
            Debug.Log(y);

            return new Vector2(xB, y);
        }

        void SpawnObjectA()
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;

                Vector2 spawnPosition = GetSpawnPointA();
                GameObject newEnemyWind = (GameObject)Instantiate(objectToSpawnA, spawnPosition, Quaternion.identity);
            }
        }

        void SpawnObjectB()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > secondsBetweenSpawn)
            {
                elapsedTime = 0;

                Vector2 spawnPosition = GetSpawnPointB();
                GameObject newEnemyWind = (GameObject)Instantiate(objectToSpawnB, spawnPosition, Quaternion.identity);
            }
        }
    }
}

