using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    public class WindModel : MonoBehaviour
    {
        public Animator windAnimator;
        public Animation angryFaceAnimation;
        public float angryFaceAnimationLenght;


        public bool windStartedBlowing;

        public WindController controller;

        void Start()
        {
            controller = transform.parent.GetComponent<WindController>();
            angryFaceAnimationLenght = angryFaceAnimation.clip.averageDuration;
            angryFaceAnimation["AngryGodFace"].speed = angryFaceAnimationLenght / controller.startWindTimer;
        }

        void Update()
        {
            if(windStartedBlowing == false)
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

