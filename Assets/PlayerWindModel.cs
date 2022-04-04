using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anemos.Gameplay
{
    public class PlayerWindModel : MonoBehaviour
    {
        public Animator playerWindAnimator;

        void Update()
        {
            StartWindAnimation();
        }

        void StartWindAnimation()
        {
            playerWindAnimator.SetTrigger("windBlowing");
        }
    }
}
