using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValuesScript : MonoBehaviour {

    // Use this for initialization
    public int playerHealth = -1;
    public float money = 0;
    

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        if (playerHealth == 0)
        {
            //go to results screen
        }
	}
}
