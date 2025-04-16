using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTorchTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameParticles;
    [SerializeField] private Light torchLight;
    public GameObject player;

    public bool isFlameActive;
    private bool playerInTrigger = false;

    void Start()
    {
        if (flameParticles != null)
        {
            flameParticles.gameObject.SetActive(false);
        }

        isFlameActive = false;

        if (torchLight != null)
        {
            torchLight.enabled = false;
        }

        playerInTrigger = false;    
    }

    void Update()
    {
        if (player == null || flameParticles == null) return;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //TurnOffFlameParticles();
            //Debug.Log("Torch Deactivated");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //ActivateTorch();
           // Debug.Log("Torch Activated");
        }

        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            ActivateTorch();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    public void ActivateTorch()
    {
        if (isFlameActive) return;

        if (flameParticles != null)
        {
            flameParticles.gameObject.SetActive(true);
            flameParticles.Play(); 
        }
        

        isFlameActive = true;
        soundManager.Instance.PlaySFX("TorchLight");

        if (torchLight != null)
        {
            torchLight.enabled = true;
        }
    }

    public void TurnOffFlameParticles()
    {
        if (flameParticles != null && flameParticles.isPlaying)
        {
            flameParticles.Stop();
        }

        if (torchLight != null)
        {
            torchLight.enabled = false;
        }

        isFlameActive = false;
    }


}