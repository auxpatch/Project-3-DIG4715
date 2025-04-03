using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTorchTrigger : MonoBehaviour
{
    public GameObject FlameParticles;
    private bool isFlameActive;

    void Start()
    {
        FlameParticles.SetActive(false);
        isFlameActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isFlameActive == true)
            {
                FlameParticles.SetActive(false);
                isFlameActive = false;
            }
            else if (isFlameActive == false)
            {
                FlameParticles.SetActive(true);
                isFlameActive = true;
            }
        }
    }
    public void ToggleFlameParticles()
    {
        isFlameActive = !isFlameActive;
        FlameParticles.SetActive(isFlameActive);
    }
}

