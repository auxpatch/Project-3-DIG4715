using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public GameObject debugPoint;
    PlayerController gameController;
   
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) //Debug for testing
        {
            respawnPoint = debugPoint;
        }
    }

    private void OnTriggerEnter(Collider other) //when the player enters the trigger collider they'll be teleported to the respawn point
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = gameController.respawnPoint.transform.position;

            Debug.Log("Player hit");
        }
    }
}
