using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxAudioSource;

    // Update is called once per fram
    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxAudioSource, spawnPosition,Quaternion.identity);
    }
}
