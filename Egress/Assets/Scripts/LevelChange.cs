using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    //AudioSource musicLoopSource;
    //AudioSource musicSource;
    //public string LevelToLoad;
    public bool redLevel;
    public bool blueLevel;
    public bool greenLevel;
    public bool hub;
    public bool winScreen;
    private bool redLevelComplete = false;
    private bool GreenLevelComplete = false;
    private bool blueLevelComplete = false;
    PlayerController playerController;
    //public GameObject WinScreen;
    private bool GameComplete;
    
    public bool FullGameComplete;
     public bool RedRoomComplete;
    public bool GreenRoomComplete;
    public bool BlueRoomComplete;
    public bool openCut = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //musicLoopSource = GetComponent<AudioSource>();
        //musicSource = GetComponent<AudioSource>();
        playerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   /*
            if (openCut)
            {
                SceneManager.LoadScene("Cutscene Opening");
            }
            */
            if (hub) 
            {   
                
                soundManager.Instance.musicLoopSource.Stop();
                soundManager.Instance.musicSource.Stop();
                soundManager.Instance.PlayMusicLoop("Hub");
                

                if (SceneManager.GetActiveScene().name == "Level - Red")
                {
                    redLevelComplete = true;
                    playerController.RedRoomComplete = true;
                    playerController.RoomsComplete++;
                    Debug.Log("Red Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Level - Green")
                {
                    GreenLevelComplete = true;
                    playerController.GreenRoomComplete = true;
                    playerController.RoomsComplete ++;
                    Debug.Log("Green Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Level - Blue")
                {
                    blueLevelComplete = true;
                    playerController.BlueRoomComplete = true;
                    playerController.RoomsComplete++;
                    Debug.Log("Blue Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Level - Tutorial")
                {
                    playerController.RoomsComplete++;
                    Debug.Log("Tutorial Level Complete");
                }
                SceneManager.LoadScene("Hub World");

            }
            else if (redLevel) 
            {    
                soundManager.Instance.musicLoopSource.Stop();
                soundManager.Instance.musicSource.Stop();
                SceneManager.LoadScene("Level - Red");
                soundManager.Instance.PlayMusic("Level1");
            }
            else if (blueLevel) 
            {
                soundManager.Instance.musicLoopSource.Stop();
                soundManager.Instance.musicSource.Stop();            
                SceneManager.LoadScene("Level - Blue");
                soundManager.Instance.PlayMusic("Level1");
            }
            else if (greenLevel) 
            {
                soundManager.Instance.musicLoopSource.Stop();
                soundManager.Instance.musicSource.Stop();            
                SceneManager.LoadScene("Level - Green");
                soundManager.Instance.PlayMusic("Level1");
            }
            else if (playerController.BlueRoomComplete && playerController.GreenRoomComplete && playerController.RedRoomComplete)
            {
                Debug.Log("Win");
                Destroy(GameObject.FindGameObjectWithTag("GameController"));
                SceneManager.LoadScene("closing cutscene");
            }
            else {Debug.Log("No Level to Load!");}
            
        }    
    }
}
