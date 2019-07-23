using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // cached references
    private GameState gamestate;

    private void Start() {
        gamestate = FindObjectOfType<GameState>();
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadNextScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadStartScene()
    {
        gamestate.ResetScore();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
