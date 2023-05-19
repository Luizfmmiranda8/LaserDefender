using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    #region VARIABLES
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

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
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        GetPlayerHealth();
        GetScore();
    }
    #endregion

    #region METHODS
    void GetPlayerHealth()
    {
        healthSlider.value = playerHealth.GetHealth();
    }

    void GetScore()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
    #endregion
}
