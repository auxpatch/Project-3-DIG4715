using UnityEngine;

public class GateOpen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerController playerChar;
    public GameObject GreenGate;
    public GameObject RedGate;
    public GameObject BlueGate;
      public GameObject GreenGem;
    public GameObject RedGem;
    public GameObject BlueGem;
    public GameObject WinDoor;

    public bool RedRoomComplete;
    public bool GreenRoomComplete;
    public bool BlueRoomComplete;

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
        if (playerChar.BlueRoomComplete == true)
        {
            Debug.Log("Red Room Gate Open");
            BlueGate.transform.position = BlueGate.transform.position + new Vector3(0,-2.5f,0);
            BlueGem.transform.position = BlueGem.transform.position + new Vector3(0,2.5f,0);
        }
        
        if (playerChar.RedRoomComplete == true)
        {
            Debug.Log("Blue Room Gate Open");
            RedGate.transform.position = RedGate.transform.position + new Vector3(0,-2.5f,0);
            RedGem.transform.position = RedGem.transform.position + new Vector3(0,2.5f,0);
        }

        if (playerChar.GreenRoomComplete == true)
        {
            Debug.Log("Green Room Gate Open");
            GreenGate.transform.position = GreenGate.transform.position + new Vector3(0,-2.5f,0);
            GreenGem.transform.position = GreenGem.transform.position + new Vector3(0,2.5f,0);
            
        }
        if (playerChar.GreenRoomComplete && playerChar.RedRoomComplete && playerChar.BlueRoomComplete)
        {
            Debug.Log("Green Room Gate Open");
            //GreenGate.transform.position = GreenGate.transform.position + new Vector3(0,2.5f,0);
            //RedGem.transform.position = RedGem.transform.position + new Vector3(0,2.5f,0);
            //BlueGem.transform.position = BlueGem.transform.position + new Vector3(0,2.5f,0);
            //GreenGem.transform.position = GreenGem.transform.position + new Vector3(0,2.5f,0);
            Destroy(WinDoor);
        }
    }
}
