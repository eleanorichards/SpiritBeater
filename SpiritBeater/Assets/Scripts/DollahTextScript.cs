using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollahTextScript : MonoBehaviour {

    public float score;
    public GameObject player;
    public GameObject txt;
    
	// Use this for initialization
	void Start () {


        txt = this.gameObject; 
	}
	
	// Update is called once per frame
	void Update () {

        score = player.GetComponent<Dollah>().DollahScore;
        GetComponent<UnityEngine.UI.Text>().text = ":" + score.ToString();
		
	}
}
