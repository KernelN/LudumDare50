using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    public class PlayerWindModel : MonoBehaviour
    {
        public Animator playerWindAnimator;

        public bool playerWindStartedBlowing;

        public PlayerWindController controller;

        void Start()
        {
            controller = transform.parent.GetComponent<PlayerWindController>();
        }


        void Update()
        {

        }

        void StartWindAnimation()
        {

        }
    }
}
