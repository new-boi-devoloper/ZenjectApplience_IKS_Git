using _Source.Services;
using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
    private readonly AudioSource _audioSource;
    private readonly AudioClip _openSound;
    private readonly AudioClip _closeSound;
    private readonly AudioClip _shootSound; // Звук выстрела
    private readonly AudioClip _destroySound;

    public SoundPlayer(AudioSource audioSource, AudioClip openSound, AudioClip closeSound, AudioClip shootSound, AudioClip destroySound)
    {
        _audioSource = audioSource;
        _openSound = openSound;
        _closeSound = closeSound;
        _shootSound = shootSound;
        _destroySound = destroySound;
    }

    public void PlayOpenSound()
    {
        _audioSource.PlayOneShot(_openSound);
    }

    public void PlayCloseSound()
    {
        _audioSource.PlayOneShot(_closeSound);
    }

    public void PlayShootSound()
    {
        _audioSource.PlayOneShot(_shootSound);
    }
    
    public void PlayDestroySound()
    {
        _audioSource.PlayOneShot(_destroySound);
    }
}