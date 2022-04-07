using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anemos.Gameplay
{
    public class PlayerWindModel : MonoBehaviour
    {
        public PlayerWindController controller;
        public Animator playerWindAnimator;
        public SpriteRenderer spriteRenderer;
        public bool fadeWind;

        void Update()
        {
            StartWindAnimation();
            if (fadeWind)
            {
                UpdateWindColor();
            }
        }

        void UpdateWindColor()
        {
            Color newFade = spriteRenderer.color;
            newFade.a = 1 - controller.publicTimer / controller.publicDuration;
            spriteRenderer.color = newFade;
        }
        void StartWindAnimation()
        {
            playerWindAnimator.SetTrigger("windBlowing");
        }
    }
}
