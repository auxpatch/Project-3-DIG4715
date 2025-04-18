using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interator : MonoBehaviour
{
       public GameObject PlayerInfo;
    public bool isPaused;
    bool isPlayerInRange = false;

    public Text interactText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
    {
        Debug.Log("[E] Was Pressed");
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    }

    void OnTriggerEnter(Collider other){
             if (other.CompareTag("Player"))
    {
        isPlayerInRange = true;
        interactText.text = "Press [E] to interact.";
    }
        }

  void OnTriggerExit(Collider other) 
            {
                Debug.Log("ijfhei");
                if(interactText.text != "")//If the interactText is not already set as nothing then set it to nothing - this is to help optimise and save from constantly spamming this request
                {
                    interactText.text = ""; //Removing the text as nothing was detected by the raycast
                }
            }

    void PauseGame()
    {
        PlayerInfo.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

     void ResumeGame()
    {
        PlayerInfo.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
