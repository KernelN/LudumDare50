using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Anemos.Gameplay
{
    public class WindController : MonoBehaviour
    {

        public AreaEffector2D effector;

        public float windForce;
        public float initialWindForce;
        public float finalWindForce;
        public float windForceTimer;

        public float windForceMod;

        public float startWindTimer;
        public float stopWindTimer;

        public float elapsedTime;

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
            //Force equals initial + ((final - initial) * time)^modifier
            //initial is the min force, final is the max force without the mod

            windForce = initialWindForce;
            windForce += (finalWindForce - initialWindForce) * elapsedTime / windForceTimer;
            windForce = Mathf.Pow(windForce, 1 + windForceMod);
            
            effector.forceVariation = windForce;
        }

        void AdvanceTimer()
        {
            elapsedTime += Time.deltaTime;
        }
    }
}

