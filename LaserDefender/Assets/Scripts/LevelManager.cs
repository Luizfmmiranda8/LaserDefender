using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region VARIABLES
    [Header("Scene Load")]
    [SerializeField] float sceneLoadDelay = 2f;

    [Header("Score")]
    ScoreKeeper scoreKeeper;
    #endregion

    #region EVENTS
    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    #endregion

    #region METHODS
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
    #endregion
}
