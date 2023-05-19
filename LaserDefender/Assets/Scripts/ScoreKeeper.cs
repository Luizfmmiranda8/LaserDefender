using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    #region VARIABLES
    [Header("Score")]
    int currentScore = 0;

    [Header("Singleton")]
    static ScoreKeeper instanceScoreKeeper;
    #endregion

    #region EVENTS
    void Awake() 
    {
        ManageSingleton();
    }
    #endregion

    #region METHODS
    public int GetScore()
    {
        return currentScore;
    }

    public void IncreaseScore(int scorePoints)
    {
        currentScore += scorePoints;

        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    void ManageSingleton()
    {
        if(instanceScoreKeeper != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instanceScoreKeeper = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
}
