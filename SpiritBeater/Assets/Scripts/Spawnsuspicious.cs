using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnsuspicious : MonoBehaviour {

    private float time = 0.0f;
    private float timeToWait = 4.0f;
	// Use this for initialization
	void Start () {
        time = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (time >= timeToWait)
        {
            GetComponent<Ghost>().isSuspicious();
        }
        if (time < timeToWait)
        {
            GetComponent<Ghost>().isIdle();
            Destroy(GetComponent<Spawnsuspicious>());
        }
    }
}
