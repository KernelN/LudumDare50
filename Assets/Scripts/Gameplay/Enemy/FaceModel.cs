using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anemos.Gameplay
{
    public class FaceModel : MonoBehaviour
    {
        public Animator faceAnimator;

        public bool isBlowing;

        public WindController controller;
      
        void Start()
        {           
            controller = transform.parent.GetComponent<WindController>();
        }

        void Update()
        {
            if (isBlowing == false)
            {
                FaceBlowingAnimation();
            }
            if (controller.elapsedTime > controller.startWindTimer)
            {
                Destroy(gameObject);
            }
        }

        void FaceBlowingAnimation()
        {
            if (controller.elapsedTime < controller.startWindTimer)
            {
                faceAnimator.SetTrigger("faceBlowing");
                isBlowing = true;
            }
        }
    }
}
