using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class StartGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stone1;
    public AudioClip stone2;

    public Slider musicSlider, sfxSlider;
    soundManager soundManager;


    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<soundManager>();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game ended.");

    }

    public void musicVolume()
    {
        soundManager.Instance.ChangeMusic(musicSlider.value);
    }

    public void sfxVolume()
    {
        soundManager.Instance.ChangeSfx(sfxSlider.value);
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