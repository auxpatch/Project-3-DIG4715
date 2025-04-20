using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    void Start()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game ended.");

    }

    public void LoadSceneStart()
    {
        soundManager.Instance.musicLoopSource.Stop();
        soundManager.Instance.musicSource.Stop();
        SceneManager.LoadScene("Level - Tutorial", LoadSceneMode.Single);
        soundManager.Instance.PlayMusicLoop("Tutorial");
        Debug.Log("Next Scene");
    }



}