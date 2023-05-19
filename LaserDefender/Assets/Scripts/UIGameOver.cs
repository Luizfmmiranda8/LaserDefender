using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    #region VARIABLES
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    #endregion

    #region EVENTS
    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();
    }
    #endregion

    #region METHODS
    #endregion
}
