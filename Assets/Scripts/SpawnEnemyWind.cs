using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyWind : MonoBehaviour
{

    public GameObject objectToSpawnA;
    public GameObject objectToSpawnB;

    float y;
    float x;

    void Start()
    {
        InvokeRepeating("SpawnObjectA", 3, 1);
        InvokeRepeating("SpawnObjectB", 3, 1);
    }

    Vector2 GetSpawnPointA()
    {
        y = Random.Range(1.30f, 3.50f);
        x = 7.5f;
        Debug.Log(y);

        return new Vector2(x, y);
    }

    Vector2 GetSpawnPointB()
    {
        y = Random.Range(1.30f, 3.50f);
        x = -7.5f;
        Debug.Log(y);

        return new Vector2(x, y);
    }

    void SpawnObjectA()
    {
        Instantiate(objectToSpawnA, GetSpawnPointA(), Quaternion.identity);
    }

    void SpawnObjectB()
    {
        Instantiate(objectToSpawnB, GetSpawnPointB(), Quaternion.identity);
    }
}
