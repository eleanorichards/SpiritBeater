using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTransferScript : MonoBehaviour {

    // Use this for initialization

    //bool for if player is currently recalling
    public bool isRecalling = false;
    //gameobject for the player - will need access to variables e.g. possessedobject
    public GameObject playerSpirit;
    public GameObject Ghost;
    public bool possessedObject = false;
    //camera object for the main camera - will need access to camera transforms and parenting
    public Camera mainCamera;
    //variable for recalling timer
    public float recallTimer;
    public float possessedGhostHealth;
    public Vector2 possessedGhostPosition;
    GameObject newPlayer;
    GameObject newGhost;





    void Start () {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

       // player = this.gameObject;
        recallTimer = 180.0f;


        
		
	}
	
	// Update is called once per frame
	void Update () {

        //if the player has not possessed an object
        if(!possessedObject)
        {

            if(Input.GetMouseButton(0))
            {
               
                //RaycastHit2D hitInfo = new RaycastHit2D();
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                    if (hit.collider.transform.gameObject.tag == "Spirit")
                    {
                        Debug.Log("It's working!");
                        GameObject target = hit.collider.transform.gameObject;
                        Possess(target);
                    }
                   
                }
                else
                {
                    Debug.Log("No hit");
                }
                
            }

        }
        else
        {
            
            if (Input.GetKey(KeyCode.B))
            {
                if(!isRecalling)
                {
                    isRecalling = true;
                }
            }
            
        }


        if(isRecalling)
        {
            if(recallTimer > 0)
            {
                recallTimer--;
            }
            else
            {
                Recall(newPlayer);
            }
        }

    }

    //This function will trigger in the update function once a timer variable hits a certain point
    void Recall(GameObject objectToLeave)
    {
       
        //When Player Recalls from a spirit:
        //time passes for recall to charge (can be interrupted if we program it)
        // When recall happens:
        // 1) The health and positions of the player spirit are stored temporarily
        // 1.5) The camera's parenting with the player spirit is nullified
        // 2) The player Spirit is destroyed 
        // 3) An AI Spirit is instantiated at the same position with the same health


        //We will want to change this to spirit health soon rather than using playervaluescript
        possessedGhostHealth = playerSpirit.GetComponent<PlayerValuesScript>().playerHealth;
        possessedGhostPosition = playerSpirit.transform.position;
        mainCamera.transform.parent = null;
        isRecalling = false;
        recallTimer = 60.0f;
        Destroy(objectToLeave.gameObject);
        newGhost = Instantiate(Ghost) as GameObject;
        Ghost.GetComponent<SpiritHealth>().currentHealth = possessedGhostHealth;
        Ghost.transform.position = possessedGhostPosition;

      


        possessedObject = false;




    }
    //This function will trigger when the player clicks on an object
    void Possess(GameObject clickedObject)
    {

        //When player possesses a spirit:
        // 1) The health and positions of the AI spirit are stored temporarily 
        // 2) The AI Spirit is Destroyed
        // 3) The player Spirit is instantiated in the same position, inheriting the health of the AI Spirit
        // 4) Camera is made a child of the player spirit

        possessedGhostHealth = clickedObject.GetComponent<SpiritHealth>().currentHealth;
        possessedGhostPosition = clickedObject.transform.position;
        Destroy(clickedObject.gameObject);
        newPlayer = Instantiate(playerSpirit) as GameObject;
        playerSpirit.transform.position = possessedGhostPosition;
        playerSpirit.GetComponent<PlayerValuesScript>().playerHealth = possessedGhostHealth;
        
        
        
        possessedObject = true;
    }


}




