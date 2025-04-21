using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class WinScreen : MonoBehaviour
{
    public GameObject Win_Screen;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Win_Screen.SetActive(false);
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
                PauseGame();
                //soundManager.Instance.musicLoopSource.Pause();
            
        }
    }

    public void PauseGame()
    {
        Win_Screen.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

}
