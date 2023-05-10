using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region VARIABLES
    [Header("Wave Config")]
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWave;

    [Header("Enemy Spawn")]
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    #endregion

    #region EVENTS
    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }
    #endregion

    #region METHODS
    IEnumerator SpawnEnemiesWaves()
    {
        do
        {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingWaypoint().position, 
                                Quaternion.Euler(0,0,180), 
                                transform);
                    
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }while(isLooping);
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    #endregion
}
