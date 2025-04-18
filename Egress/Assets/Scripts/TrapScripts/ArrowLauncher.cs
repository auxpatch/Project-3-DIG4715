using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject arrow;

    public Transform spawnLocation;

    public Quaternion spawnRotation;

    public float spawnTime = 3f;

    private float timeSinceSpawned = 0f; // Time in seconds between each arrow spawn
    void Start()
    {

    }

    void Update()
    {

        timeSinceSpawned += Time.deltaTime;

        if (timeSinceSpawned >= spawnTime)
        {
            Instantiate(arrow, spawnLocation.position, spawnRotation);
            timeSinceSpawned = 0;
        }
    }
}
