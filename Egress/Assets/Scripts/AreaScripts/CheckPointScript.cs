using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public RespawnScript respawn;
    public PlayerController gameController;


    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>(); // Find the RespawnScript component on the GameObject with the "Respawn" tag
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
    }
    
    void Start()
    {
        //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //soundManager.Instance.PlaySFX("CheckpointDing");
        if(other.gameObject.CompareTag("Player"))
        {
            //GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>().respawnPoint = this.gameObject;
            
            //gameController.respawnPoint.transform.position = transform.position;
            gameController.respawnPoint = this.gameObject;
            //respawn.respawnPoint1 = gameController.respawnPoint;
            //respawn.respawnPoint = this.gameObject; // When the player enters the checkpoint, set the respawn point to this checkpoint
        }
    }
    
}
