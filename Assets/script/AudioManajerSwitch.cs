using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManajerSwitch : MonoBehaviour
{
   public AudioSource bgmAudioSource;
    public AudioSource switchOnAudioSource; // Suara switch menyala
    public AudioSource switchOffAudioSource; // Suara switch mati

    // Start is called before the first frame update
    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Play();
        }
    }

    public void PlaySwitchOnSFX(Vector3 spawnPosition)
    {
        PlaySFX(spawnPosition, switchOnAudioSource);
    }

    public void PlaySwitchOffSFX(Vector3 spawnPosition)
    {
        PlaySFX(spawnPosition, switchOffAudioSource);
    }

    private void PlaySFX(Vector3 spawnPosition, AudioSource audioSource)
    {
        if (audioSource != null)
        {
            GameObject sfx = Instantiate(audioSource.gameObject, spawnPosition, Quaternion.identity);
            AudioSource newAudioSource = sfx.GetComponent<AudioSource>();
            if (newAudioSource != null)
            {
                newAudioSource.Play();
                Destroy(sfx, newAudioSource.clip.length);
            }
        }
    }
}
