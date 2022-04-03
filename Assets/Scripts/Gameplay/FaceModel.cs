using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    public class FaceModel : MonoBehaviour
    {
        public Animator faceAnimator;

        public bool isBlinking;

        public WindController controller;

        // Start is called before the first frame update
        void Start()
        {
            controller = transform.parent.GetComponent<WindController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isBlinking == true)
            {
                FaceAnimation();
            }
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
