using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    public class FaceModel : MonoBehaviour
    {
        public Animator faceAnimator;
        public SpriteRenderer faceRenderer;

        public bool isBlinking;

        public WindController controller;
      
        void Start()
        {
            controller = transform.parent.GetComponent<WindController>();
            faceRenderer.enabled = false;
        }

        void Update()
        {
            if (isBlinking == true)
            {
                FaceAnimation();
                
            }
            faceRenderer.enabled = true;
        }

        void FaceAnimation()
        {
            if (controller.elapsedTime < controller.startWindTimer)
            {
                faceAnimator.SetTrigger("faceBlinking");
                isBlinking = false;
            }
        }
    }
}
