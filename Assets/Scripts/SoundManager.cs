using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonPattern<SoundManager>
{
    
    public AudioClip clip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}
