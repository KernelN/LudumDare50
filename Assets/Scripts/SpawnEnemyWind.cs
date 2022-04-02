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

        float y;
        float x;

        void Update()
        {
            SpawnObjectA();
            SpawnObjectB();
        }

        Vector2 GetSpawnPointA()
        {
            y = Random.Range(-0.20f,2.45f);
            x = 7.5f;
            Debug.Log(y);

            return new Vector2(x, y);
        }

        Vector2 GetSpawnPointB()
        {
            y = Random.Range(-0.20f, 2.45f);
            x = -7.5f;
            Debug.Log(y);

            return new Vector2(x, y);
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

