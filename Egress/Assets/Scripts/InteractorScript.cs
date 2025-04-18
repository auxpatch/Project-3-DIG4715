using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractorScript : MonoBehaviour
{

    public GameObject PlayerInfo;
    public bool isPaused;

    float raycastDistance = 6; //Adjust to suit your use case

    public Text interactText; //Create GUI Canvas on your scene if you havnt already and a UI Text Element in a suitable location on your screen and apply it to this Text variable

	void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // This creates a 'ray' at the Main Camera's Centre Point essentially the centre of the users Screen

        RaycastHit hit; //This creates a Hit which is used to callback the object that was hit by the Raycast

        if (Physics.Raycast(ray, out hit, raycastDistance)) //Actively creates a ray using the above set perameters at the predeterminded distance
        {
            //Item Raycast Detection
            if (hit.collider.CompareTag("tablet"))//Checking if the Raycast has hit a collider with the tag of note
            {
                interactText.text = "Press [E] to interact."; //Setting the Interaction Text to let the player know they are now hovering an interactable object
                
                if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
                {
                    Debug.Log("[E] Was Pressed while looking at a note, lets open the note.");

                   if(isPaused)
                    {
                        ResumeGame();
                    }
                    else
                    {
                        PauseGame();
                    }
                    }
                }
            }
            

            else //If nothing at all with an above tag was hit with the Raycast within the specified distance then run this
            {
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
}