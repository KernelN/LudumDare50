using UnityEngine;

namespace Universal.Audio
{
    [RequireComponent(typeof(AudioListener))]
    [RequireComponent(typeof(AudioSource))]
    public class AudioReceiver : MonoBehaviour
    {
        [Header("Set Values")]
        [SerializeField] AudioSource source;

        [Header("Runtime Values")]
        [SerializeField] GlobalAudioManager manager;

        //Unity Events
        private void Start()
        {
            if (manager == null)
            {
                manager = GlobalAudioManager.Get();
            }
            if (source == null)
            {
                source = GetComponent<AudioSource>();
            }

            manager.publicSource = source;
        }
    }
}