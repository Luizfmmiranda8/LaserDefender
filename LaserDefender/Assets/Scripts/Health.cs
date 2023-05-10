using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region VARIABLES
    [Header("Health")]
    [SerializeField] int health = 50;
    #endregion

    #region EVENTS
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
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
    #endregion
}
