using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemyWindAudio : MonoBehaviour
    {
        [Header("Set Values")]
        [SerializeField] AudioSource source;
        [SerializeField] AudioClip windHowlingSFX;

        [Header("Runtime Values")]
        [SerializeField] WindController controller;

        //Unity Events
        private void Start()
        {
            if (source == null)
            {
                source = GetComponent<AudioSource>();
            }

            if (controller == null)
            {
                controller = GetComponent<WindController>();
            }

            controller.WindStarted += OnWindStarted;
        }
        private void OnDestroy()
        {
            controller.WindStarted -= OnWindStarted;
        }

        //Event Receivers
        void OnWindStarted()
        {
            source.PlayOneShot(windHowlingSFX);
        }
    }
}