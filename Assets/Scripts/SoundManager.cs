using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonPattern<SoundManager>
{
    
    public AudioClip clip;
    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    public void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }
}
