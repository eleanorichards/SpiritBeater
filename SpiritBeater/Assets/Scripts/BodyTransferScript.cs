using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTransferScript : MonoBehaviour {

    // Use this for initialization

    //bool for if player is currently recalling
    public bool isRecalling = false;
    //gameobject for the player - will need access to variables e.g. possessedobject
    public GameObject player;
    public GameObject possessedObject = null;
    //camera object for the main camera - will need access to camera transforms and parenting
    public Camera mainCamera;
    //variable for recalling timer
    public float recallTimer;


	void Start () {

        mainCamera = Camera.main;

        player = this.gameObject;
        recallTimer = 180.0f;


        
		
	}
	
	// Update is called once per frame
	void Update () {

        //if the player has not possessed an object
        if(possessedObject == null)
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
            if(Input.GetKey(KeyCode.B))
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
                Recall();
            }
        }

    }

    //This function will trigger in the update function once a timer variable hits a certain point
    void Recall()
    {
        //Set possessedObject to null
        //unparent camera from possessed object if necessary

        possessedObject.GetComponent<PlayerMoverment>().IsPossessed(false);
        possessedObject.GetComponent<NavMeshAgent2D>().enabled = true;
        possessedObject.GetComponent<Ghost>().enabled = true;
        possessedObject = null;
        mainCamera.transform.parent = null;
        isRecalling = false;
        recallTimer = 60.0f;
        player.GetComponent<PlayerValuesScript>().playerHealth = -1;

        
        
       


    }
    //This function will trigger when the player clicks on an object
    void Possess(GameObject clickedObject)
    {

        possessedObject = clickedObject;
        mainCamera.transform.position = new Vector3(clickedObject.transform.position.x, clickedObject.transform.position.y, -10);
        mainCamera.transform.parent = clickedObject.transform;
        player.GetComponent<PlayerValuesScript>().playerHealth = clickedObject.GetComponent<SpiritHealth>().currentHealth;
        clickedObject.GetComponent<PlayerMoverment>().possessed = true;
        clickedObject.GetComponent<NavMeshAgent2D>().enabled = false;
        clickedObject.GetComponent<Ghost>().enabled = false;
        clickedObject.gameObject.GetComponent<Ghost>().IsPossessed(true);
        //Set player health to health of the possessed object



        //Set clickedObject's possessed variable to true
        //Move camera to same position on X/Y axis as the clicked object 
        //Make camera a child of the possessed Object

    }

  
}
