using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTorchTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameParticles;
    [SerializeField] private Light torchLight;
    [SerializeField] private Transform player;
    [SerializeField] private float activationDistance = 3f;

    private bool isFlameActive;

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
    }

    void Update()
    {
        if (player == null || flameParticles == null) return;

        if (IsPlayerWithinActivationDistance() && Input.GetKeyDown(KeyCode.E))
        {
            ActivateTorch();
        }
    }

    private bool IsPlayerWithinActivationDistance()
    {
        float sqrDistance = (player.position - transform.position).sqrMagnitude;
        return sqrDistance <= activationDistance * activationDistance;
    }

    private void ActivateTorch()
    {
        if (isFlameActive) return;

        if (flameParticles != null)
        {
            flameParticles.gameObject.SetActive(true);
            flameParticles.Play(); 
        }

        isFlameActive = true;

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