using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anemos.Gameplay
{
    public class WindModel : MonoBehaviour
    {
        public Animator windAnimator;

        public bool windStartedBlowing;

        public WindController controller;

        void Start()
        {
            controller = transform.parent.GetComponent<WindController>();
        }

        void Update()
        {
            if (windStartedBlowing == false)
            {
                StarBlowAnimation();
            }
        }

        void StarBlowAnimation()
        {
            if(controller.elapsedTime > controller.startWindTimer)
            {
                windAnimator.SetTrigger("windBlowing");
                windStartedBlowing = true;
            }
        }
    }
}

