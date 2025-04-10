using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game ended.");

    }

    public void LoadSceneHub()
    {
        SceneManager.LoadScene("Hub World");
        Debug.Log("Next Scene");
    }



}