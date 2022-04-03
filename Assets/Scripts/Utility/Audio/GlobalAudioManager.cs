using UnityEngine;
using Universal.Singletons;

namespace Universal.Audio
{
    public class GlobalAudioManager : MonoBehaviourSingletonInScene<GlobalAudioManager>
    {
        [Header("Set Values")]
        [SerializeField] NAMESPACENAME.GameManager manager;
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip gameplayMusic;
        [SerializeField] AudioClip menuMusic;
        [SerializeField] float volumeFadeLength;
        [SerializeField] float minVolume;

        [Header("Runtime Values")]
        [SerializeField] AudioSourceData sourceData;
        [SerializeField] float fadeTimer;
        [SerializeField] bool playGameplayMusic;
        [SerializeField] bool playingGameplayMusic;
        
        public AudioSource publicSource { set { audioSource = value; UpdateSource(); } }

        //Unity Events
        private void Start()
        {
            manager.SceneChanged += OnSceneChanged;

            fadeTimer = volumeFadeLength;

            audioSource.clip = playGameplayMusic ? gameplayMusic : menuMusic;
            audioSource.Play();
            UpdateSourceData();

            //Makes the Music Player start the Fade In Sequence
            playingGameplayMusic = !playGameplayMusic;
        }
        private void OnDestroy()
        {
            manager.SceneChanged -= OnSceneChanged;
        }
        private void Update()
        {
            if (playGameplayMusic != playingGameplayMusic)
            {
                SwitchMusic();
            }
            else if (fadeTimer < volumeFadeLength)
            {
                FadeVolume(false);
            }

            UpdateSourceData();
        }

        //Methods
        void FadeOutVolume()
        {
            if (fadeTimer / volumeFadeLength <= minVolume)
            {
                audioSource.Stop();
                return;
            }

            fadeTimer -= Time.unscaledDeltaTime;
            audioSource.volume = fadeTimer;
        }
        void FadeInVolume()
        {
            if (fadeTimer / volumeFadeLength <= minVolume)
            {
                audioSource.Play();
            }
            else if (fadeTimer >= volumeFadeLength) return;
         
            fadeTimer += Time.unscaledDeltaTime;
            audioSource.volume = fadeTimer;
        }
        void FadeVolume(bool fadeOut)
        {
            if (fadeOut)
            {
                FadeOutVolume();
            }
            else
            {
                FadeInVolume();
            }
            UpdateSourceData();
        }
        void SwitchMusic()
        {
            //Use volume fade out
            if (fadeTimer / volumeFadeLength > minVolume)
            {
                FadeVolume(true);
                return;
            }

            audioSource.clip = playGameplayMusic ? gameplayMusic : menuMusic;
            audioSource.time = 0;
            UpdateSourceData();

            playingGameplayMusic = playGameplayMusic;
        }
        void UpdateSource()
        {
            if (audioSource == null) return;
            if (sourceData == null) return;

            audioSource.loop = true;
            audioSource.volume = sourceData.volume;
            audioSource.clip = sourceData.clip;
            audioSource.time = sourceData.time;

            if (sourceData.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
        void UpdateSourceData()
        {
            if (sourceData == null) sourceData = new AudioSourceData();
            if (audioSource == null) return;

            sourceData.clip = audioSource.clip;
            sourceData.volume = audioSource.volume;
            sourceData.time = audioSource.time;
            sourceData.isPlaying = audioSource.isPlaying;
        }

        //Event Receivers
        void OnSceneChanged()
        {
            playGameplayMusic = 
                (manager.targetScene == SceneManaging.Scenes.gameplay);
            
        }
    }
}