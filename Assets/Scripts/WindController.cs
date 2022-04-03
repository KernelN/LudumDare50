using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NAMESPACENAME.Gameplay
{
    public class WindController : MonoBehaviour
    {
        public AreaEffector2D effector;
        
        public float initialWindForce;
        public float finalWindForce;
        public float windForceTimer;

        public float windForce;

        public float startWindTimer;
        public float stopWindTimer;

        public float elapsedTime;
        public float elapsedStopTime;

        public float windAngle { set { effector.forceAngle = value; } }

        // Start is called before the first frame update
        void Start()
        {
            effector.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            StartWind();
            IncrementWindForce();
            StopWind();
        }

        //After x seconds the wind starts blowing.
        void StartWind()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > startWindTimer)
            {
                effector.enabled = true;
            }
        }

        void StopWind()
        {
            elapsedStopTime += Time.deltaTime;
            if (elapsedStopTime > stopWindTimer)
            {
                //effector.enabled = false;
                Destroy(gameObject);
            }
        }

        void IncrementWindForce()
        {
            effector.forceVariation = initialWindForce * windForce;           

            elapsedTime += Time.deltaTime;
            if(elapsedTime > windForceTimer)
            {
                effector.forceVariation = finalWindForce * windForce;
            }
        }
    }
}

