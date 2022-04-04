using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Anemos.Gameplay
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

        public System.Action WindStarted;

        public float windAngle { set { effector.forceAngle = value; } }

        void Start()
        {
            effector.enabled = false;
        }

        void Update()
        {
            AdvanceTimer();

            StartWind();
            IncrementWindForce();
            StopWind();
        }

        //After x seconds the wind starts blowing.
        void StartWind()
        {
            //Prevents function to be called once the wind already started
            if (effector.enabled) return;

            if (elapsedTime > startWindTimer)
            {
                effector.enabled = true;
                WindStarted?.Invoke();
            }
        }

        //After x seconds the wind stops blowing.
        void StopWind()
        {
            if (elapsedTime > stopWindTimer)
            {
                effector.enabled = false;
                Destroy(this.gameObject);
            }
        }

        void IncrementWindForce()
        {
            effector.forceVariation = initialWindForce * windForce;

            if (elapsedTime > windForceTimer)
            {
                effector.forceVariation = finalWindForce * windForce;
            }
        }

        void AdvanceTimer()
        {
            elapsedTime += Time.deltaTime;
        }
    }
}

