using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnsuspicious : MonoBehaviour {

    private float time = 0.0f;
    private float timeToWait = 4.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time <= timeToWait)
        {
            GetComponent<Ghost>().isSuspicious();
            print("Still suspicious");
        }
        if (time > timeToWait)
        {
            GetComponent<Ghost>().isIdle();
            print("not suspicious");
        }
    }
}
