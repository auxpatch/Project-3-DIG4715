using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    //public string LevelToLoad;
    public bool redLevel;
    public bool lightroomLevel;
    public bool greenLevel;
    public bool hub;
    private bool redLevelComplete = false;
    private bool GreenLevelComplete = false;
    private bool LightroomLevelComplete = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (hub) 
            {   
                
                if (SceneManager.GetActiveScene().name == "Level - Red")
                {
                    redLevelComplete = true;
                    Debug.Log("Red Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Level - Green")
                {
                    GreenLevelComplete = true;
                    Debug.Log("Green Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Light Room")
                {
                    LightroomLevelComplete = true;
                    Debug.Log("Light Room Complete");
                }
                SceneManager.LoadScene("Hub World");
            }
            else if (redLevel) {SceneManager.LoadScene("Level - Red");}
            else if (lightroomLevel) {SceneManager.LoadScene("Light Room");}
            else if (greenLevel) {SceneManager.LoadScene("Level - Green");}
            else {Debug.Log("No Level to Load!");}
            
        }    
    }
}
