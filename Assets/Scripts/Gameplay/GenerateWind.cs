using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWind : MonoBehaviour
{

    //public BoxCollider2D collider;
    public GameObject wind;
    public AreaEffector2D effector;

    Camera cam;
    Vector3 startPoint;
    Vector3 endPoint;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;
            //Debug.Log(startPoint); 

            if (startPoint.x <= -1) //Si se hizo click del lado izquierdo...
            {
                effector.forceAngle = 0; //Sopla viento hacia la derecha.
            }
            else
            {
                effector.forceAngle = 180; //Si no, hacia la izquierda.
            }

            Instantiate(wind, startPoint, Quaternion.identity);
            Destroy(wind, 1f);           
        }

    }
}
