using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    private AudioSource source;

    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    public void ChangeBGMusic(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
