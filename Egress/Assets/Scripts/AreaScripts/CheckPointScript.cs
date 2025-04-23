using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private RespawnScript respawn;

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>(); // Find the RespawnScript component on the GameObject with the "Respawn" tag
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //soundManager.Instance.PlaySFX("CheckpointDing");
        if(other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject; // When the player enters the checkpoint, set the respawn point to this checkpoint
        }
    }
    
}
