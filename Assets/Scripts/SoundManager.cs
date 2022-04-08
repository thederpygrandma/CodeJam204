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

    /// <summary>
    /// Plays the clip one time in its entirety 
    /// </summary>
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
