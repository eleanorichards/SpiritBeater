using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInRange : MonoBehaviour {

    public List<Collider2D> triggerList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spirit")
        {
            triggerList.Add(col);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spirit")
        {
            triggerList.Remove(col);
        }
    }
}
