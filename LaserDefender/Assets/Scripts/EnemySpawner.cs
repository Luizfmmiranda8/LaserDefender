using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region VARIABLES
    [Header("Wave Config")]
    [SerializeField] WaveConfigSO currentWave;
    #endregion

    #region EVENTS
    void Start()
    {
        SpawnEnemies();
    }
    #endregion

    #region METHODS
    void SpawnEnemies()
    {
        for(int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), 
                        currentWave.GetStartingWaypoint().position, 
                        Quaternion.identity, 
                        transform);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    #endregion
}
