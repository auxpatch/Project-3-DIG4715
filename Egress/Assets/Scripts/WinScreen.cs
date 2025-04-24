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
        //Win_Screen.SetActive(true);
        //PauseGame();
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Win_Screen.activeSelf)
        //{
        //        PauseGame();
                //soundManager.Instance.musicLoopSource.Pause();
            
        //}
    }

    //public void PauseGame()
    //{

        //isPaused = true;
        //Time.timeScale = 0f;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    //}
    
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

}
