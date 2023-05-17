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

    [Header("SFX")]
    AudioPlayer audioPlayer;

    [Header("Score")]
    [SerializeField] int scorePoints = 50;
    ScoreKeeper scoreKeeper;

    [Header("Player")]
    [SerializeField] bool isPlayer;

    [Header("Level Manager")]
    LevelManager levelManager;
    #endregion

    #region EVENTS
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
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
    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int amountDamage)
    {
        health -= amountDamage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.IncreaseScore(scorePoints);
        }
        else
        {
            levelManager.LoadGameOver();
        }

        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem hitEffectInstance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            audioPlayer.PlayDamageClip();
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
