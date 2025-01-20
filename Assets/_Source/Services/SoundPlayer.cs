using UnityEngine;

namespace _Source.Services
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly AudioSource _audioSource;
        
        private readonly AudioClip _closeSound;
        private readonly AudioClip _openSound;

        public SoundPlayer(AudioSource audioSource, AudioClip openSound, AudioClip closeSound)
        {
            _audioSource = audioSource;
            _openSound = openSound;
            _closeSound = closeSound;
        }

        public void PlayOpenSound()
        {
            _audioSource.PlayOneShot(_openSound);
        }

        public void PlayCloseSound()
        {
            _audioSource.PlayOneShot(_closeSound);
        }
    }
}