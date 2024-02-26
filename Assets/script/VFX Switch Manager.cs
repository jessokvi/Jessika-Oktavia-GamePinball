using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSwitchManager : MonoBehaviour
{
    public GameObject switchOnVFXSource; // Suara switch menyala
    public GameObject switchOffVFXSource; // Suara switch mati

    public void PlaySwitchOnVFX(Vector3 spawnPosition)
    {
        PlayVFX(spawnPosition, switchOnVFXSource);
    }

    public void PlaySwitchOffVFX(Vector3 spawnPosition)
    {
        PlayVFX(spawnPosition, switchOffVFXSource);
    }

    private void PlayVFX(Vector3 spawnPosition, GameObject vfxPrefab)
    {
        if (vfxPrefab != null)
        {
            GameObject vfx = Instantiate(vfxPrefab, spawnPosition, Quaternion.identity);
            // Tambahan logika atau konfigurasi efek visual di sini jika diperlukan
            Destroy(vfx, GetVFXDuration(vfx));
        }
    }

    private float GetVFXDuration(GameObject vfx)
    {
        var particleSystem = vfx.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            return particleSystem.main.duration;
        }
        return 2.0f; // Atau nilai default jika tidak ada komponen yang sesuai
    }
}
