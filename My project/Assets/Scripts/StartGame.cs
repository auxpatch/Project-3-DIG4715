using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("GameplayPrototype");
        Debug.Log("Next Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game ended.");

    }

    public void LoadSceneLvl1()
    {
        SceneManager.LoadScene("Level 1");
        Debug.Log("Next Scene");
    }
}