using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int RoomsComplete = 0;
    private PlayerController playerCont;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() {
    if (GameObject.FindGameObjectsWithTag("GameController").Length > 1){
        Destroy(gameObject);
    }
    else {
        //initialize
    }
}
    void Start()
    {
        //RoomsComplete = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
