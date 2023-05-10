using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    #region VARIABLES
    [Header("Damage")]
    [SerializeField] int damage = 10;
    #endregion

    #region METHODS
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    #endregion
}
