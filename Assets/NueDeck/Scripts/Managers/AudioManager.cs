using UnityEngine;

namespace NueDeck.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        public AudioSource musicSource;
        public AudioSource sfxSource;
        public AudioSource buttonSource;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void PlayMusic(AudioClip clip)
        {
            if (clip)
            {
                musicSource.clip = clip;
                musicSource.Play();
            }
           
        }

        public void PlayOneShot(AudioClip clip)
        {
            if (clip)
            {
                sfxSource.PlayOneShot(clip);
            }
        }
        
        public void PlayOneShotButton(AudioClip clip)
        {
            if (clip)
            {
                buttonSource.PlayOneShot(clip);
            }
        }
    }
}
