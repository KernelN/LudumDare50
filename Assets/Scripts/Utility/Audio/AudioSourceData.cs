using UnityEngine;

namespace Universal.Audio
{
    [System.Serializable]
    public class AudioSourceData
    {
        public AudioClip clip;
        public float volume;
        public float time;
        public bool isPlaying;
    }
}