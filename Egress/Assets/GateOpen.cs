using UnityEngine;

public class GateOpen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerController playerChar;
    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject Gate3;

    void Start()
    {
        
        playerChar = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
        if (playerChar == null)
        {
            Debug.Log("no player found");
        }
        else {Debug.Log("Player found");}
        //.GetComponent<Player>();
        OpenGate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenGate()
    {
        Debug.Log(playerChar.RoomsComplete);
        if (playerChar.RoomsComplete == 1)
        {
            Debug.Log("Green Room Gate Open");
            Gate1.transform.position = Gate1.transform.position + new Vector3(0,2.5f,0);
        }
        
        if (playerChar.RoomsComplete == 2)
        {
            Debug.Log("Blue Room Gate Open");
            Gate2.transform.position = Gate2.transform.position + new Vector3(0,2.5f,0);
        }

        if (playerChar.RoomsComplete == 3)
        {
            Debug.Log("Red Room Gate Open");
            Gate3.transform.position = Gate3.transform.position + new Vector3(0,2.5f,0);
        }
    }
}
