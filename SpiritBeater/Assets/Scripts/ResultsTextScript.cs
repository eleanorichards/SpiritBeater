using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsTextScript : MonoBehaviour {


    bool win = false;
    
	// Use this for initialization
	void Start () {
        if (win)
        {
            GetComponent<UnityEngine.UI.Text>().text = "YOU WON";
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().text = "GAME OVER...";
        }

    }
	
	// Update is called once per frame
	void Update () {

        //if playerwins variable is true, set text to 'YOU WON' or something
        
        //else, set text to 'Game Over...' or something
		
	}
}
