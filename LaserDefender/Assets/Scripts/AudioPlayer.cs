using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    #region VARIABLES
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingClipVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageClipVolume = 1f;
    #endregion

    #region EVENTS
    #endregion

    #region METHDOS
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingClipVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageClipVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;

            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
    #endregion
}
