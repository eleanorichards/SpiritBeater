using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    private float time = 0.0f;
    private float timeBetweenPunches = 1.0f;

    private GameObject enemy;
	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
            if (time >= timeBetweenPunches)
            {
                time = 0.0f;
                //Deal damage needs to be called
            }

        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        enemy = col.gameObject;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        enemy = null;
    }
}
