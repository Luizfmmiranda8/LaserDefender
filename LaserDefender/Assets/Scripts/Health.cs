using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region VARIABLES
    [Header("Health")]
    [SerializeField] int health = 50;

    [Header("Effects")]
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    #endregion

    #region EVENTS
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    #endregion

    #region METHODS
    void TakeDamage(int amountDamage)
    {
        health -= amountDamage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem hitEffectInstance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectInstance.gameObject, hitEffectInstance.main.duration + hitEffectInstance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    #endregion
}
