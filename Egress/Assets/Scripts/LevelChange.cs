using System.Collections;
using System.Collections.Generic;
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
    private bool redLevelComplete = false;
    private bool GreenLevelComplete = false;
    private bool blueLevelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        //musicLoopSource = GetComponent<AudioSource>();
        //musicSource = GetComponent<AudioSource>();
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
                soundManager.Instance.musicLoopSource.Stop();
                soundManager.Instance.musicSource.Stop();
                soundManager.Instance.PlayMusicLoop("Hub");

                if (SceneManager.GetActiveScene().name == "Level - Red")
                {
                    redLevelComplete = true;
                    Debug.Log("Red Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Level - Green")
                {
                    GreenLevelComplete = true;
                    Debug.Log("Green Level Complete");
                } else if (SceneManager.GetActiveScene().name == "Level - Blue")
                {
                    blueLevelComplete = true;
                    Debug.Log("Blue Level Complete");
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
            else {Debug.Log("No Level to Load!");}
            
        }    
    }
}
