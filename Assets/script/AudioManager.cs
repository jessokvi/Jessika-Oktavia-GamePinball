using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlayCommonSFX(Vector3 SpawnPosition)
    {
        GameObject.Instantiate(sfxAudioSource, SpawnPosition, Quaternion.identity); 
    }
}
