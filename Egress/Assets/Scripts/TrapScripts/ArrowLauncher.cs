using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject arrow;

    public Transform spawnLocation;

    public Quaternion spawnRotation;

    public float spawnTime = 0.5f;

    private float timeSinceSpawned = 0f; 
    void Start()
    {
        
    }

    void Update()
    {
        Instantiate(arrow, spawnLocation.position, spawnRotation);

        timeSinceSpawned += Time.deltaTime;

        if(timeSinceSpawned >= spawnTime)
        {
            Instantiate(arrow, spawnLocation.position, spawnRotation);
            timeSinceSpawned = 0;
        }
    }
}
