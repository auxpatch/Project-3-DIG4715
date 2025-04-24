using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stone1;
    public AudioClip stone2;


    void Start()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game ended.");

    }

    public void tabletsound()
    {
      audioSource.PlayOneShot(stone1);
    }

    public void tabletleavesound()
    {
        audioSource.PlayOneShot(stone2);
    }
    public void LoadSceneStart()
    {
        soundManager.Instance.musicLoopSource.Stop();
        soundManager.Instance.musicSource.Stop();
        soundManager.Instance.PlayMusicLoop("Tutorial");
        SceneManager.LoadScene("Level - Tutorial", LoadSceneMode.Single);
        Debug.Log("Next Scene");
    }



}