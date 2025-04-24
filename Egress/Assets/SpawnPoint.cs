using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerController gameController;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
        gameController.respawnPoint = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
