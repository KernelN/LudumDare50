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

        void Start()
        {
            effector.enabled = false;
        }

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

        //After x seconds the wind stops blowing.
        void StopWind()
        {           
            elapsedStopTime += Time.deltaTime;
            if (elapsedStopTime > stopWindTimer)
            {
                effector.enabled = false;
                Destroy(this.gameObject);
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

