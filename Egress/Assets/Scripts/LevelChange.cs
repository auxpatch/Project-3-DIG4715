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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (hub) {SceneManager.LoadScene("Hub World");}
            else if (redLevel) {SceneManager.LoadScene("Level - Red");}
            else if (lightroomLevel) {SceneManager.LoadScene("Light Room");}
            else if (greenLevel) {SceneManager.LoadScene("Level - Green");}
            else {Debug.Log("No Level to Load!");}
            
        }    
    }
}
