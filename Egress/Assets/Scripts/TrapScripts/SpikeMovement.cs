using UnityEngine;
using System.Collections;

public class SpikeMovement : MonoBehaviour
{
    public float moveSpeed = 6f; //spike speed
    public float moveDistance = 0.5f;

    void Start()
    {
        StartCoroutine(RunLoop());
    }

    private IEnumerator RunLoop()
    {
        float movedDistance = 0f;

        while (movedDistance < moveDistance)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * step); //move the spikes up 
            moveDistance += step;

            yield return new WaitForSeconds(0f); 
        }

    }


}
