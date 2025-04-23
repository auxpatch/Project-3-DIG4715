using UnityEngine;

public class Arrow2 : MonoBehaviour
{
    public float moveSpeed = 10f; //arrow speed

    //arrow time to live
    public float timeToLive = 5f;

    private float timeSinceSpawned = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); //move the arrow left

        timeSinceSpawned += Time.deltaTime;

        if (timeSinceSpawned > timeToLive)
        {
            Destroy(gameObject); //destroy the arrow after timeToLive seconds
        }
    }
}
