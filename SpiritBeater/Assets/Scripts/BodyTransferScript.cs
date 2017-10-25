using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTransferScript : MonoBehaviour {

	// Use this for initialization

        //bool for if player is currently recalling
        //gameobject for the player - will need access to variables e.g. possessedobject
        //camera object for the main camera - will need access to camera transforms and parenting
        //variable for recalling timer


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if the player has not possessed an object
        //{
        //if mouse clicked
        //{
        //if mouse is clicking on an object with the tag 'spirit'
        //{
        //call the possess function passing in the clicked object
        //}
        //}
        //}
 
        //else 
        //{
        //if b button is pressed
        //{
        //if player is not recalling
        //{
        //set recalling variable to true
        //}
        //}
        //}


        //if recalling is true
        //{
        //if recall timer is more than 0
        //{
        //recall timer down 1 frame
        //}
        //else
        //{
        //Reset recall timer
        //Call recall function
        //}
        //}

		
	}

    //This function will trigger in the update function once a timer variable hits a certain point
    void Recall()
    {

        //Set possessedObject to null
        //unparent camera from possessed object if necessary


    }
    //This function will trigger when the player clicks on an object
    void Possess(GameObject clickedObject)
    {

        //Set possessedObject to the clicked object
        //Set clickedObject's possessed variable to true
        //Move camera to same position on X/Z axis as the clicked object 
        //Make camera a child of the possessed Object

    }
}
