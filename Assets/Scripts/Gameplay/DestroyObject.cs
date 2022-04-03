using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float despawnTimer;

    void Start()
    {
        Destroy(this.gameObject, despawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
