using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    public bool isPaused;

    public Slider musicSlider, sfxSlider;
    soundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false);
        //Time.timeScale = 0;
        soundManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<soundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
                //soundManager.Instance.musicLoopSource.UnPause();
            }
            else
            {
                PauseGame();
                //soundManager.Instance.musicLoopSource.Pause();
            }
        }
    }

    public void PauseGame()
    {
        Pausemenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        soundManager.toggleMusic();
    }

    public void ResumeGame()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        soundManager.toggleMusic();
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        soundManager.toggleMusic();
        SceneManager.LoadScene("Start Screen");
        
    }

     public void ToHub()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hub World");
        soundManager.Instance.musicSource.Stop();
        soundManager.Instance.PlayMusicLoop("Hub");
        
    }

    public void ToggleMusic()
    {
        soundManager.Instance.toggleMusic();
    }

    public void ToggleSfx()
    {
        soundManager.Instance.toggleSfx();
    }

    public void musicVolume()
    {
        soundManager.Instance.ChangeMusic(musicSlider.value);
    }

    public void sfxVolume()
    {
        soundManager.Instance.ChangeSfx(sfxSlider.value);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
