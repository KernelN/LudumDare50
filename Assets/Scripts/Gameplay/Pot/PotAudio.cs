using UnityEngine;

namespace NAMESPACENAME.Gameplay
{
    [RequireComponent(typeof(AudioSource))]
    public class PotAudio : MonoBehaviour
    {
        [Header("Set Values")] 
        [SerializeField] AudioSource source;
        [SerializeField] AudioClip potBreakingSFX;

        //Unity Events
        private void Start()
        {
            if (source == null)
            {
                source = GetComponent<AudioSource>();
            }

            GameplayManager.Get().PotFalled += OnPotFalled;
        }
        private void OnDestroy()
        {
            GameplayManager.Get().PotFalled -= OnPotFalled;
        }

        //Event Receivers
        void OnPotFalled()
        {
            source.PlayOneShot(potBreakingSFX);
        }
    }
}