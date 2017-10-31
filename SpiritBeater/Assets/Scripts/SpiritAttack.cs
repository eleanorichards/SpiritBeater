using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAttack : MonoBehaviour {

    
    private float time = 0.0f;
    private float timeBetweenPunches = 1.0f;
    private Ghost.SpiritState spirState;
	// Use this for initialization
	void Start () {
        time = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (spirState == Ghost.SpiritState.Attack)
        {
            time += Time.deltaTime;
            if (time >= timeBetweenPunches)
            {
                time = 0.0f;
                //Damage Player controlled Spirit
            }
        }
	}
}
