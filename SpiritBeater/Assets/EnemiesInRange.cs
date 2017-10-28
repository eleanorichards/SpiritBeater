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
        triggerList.Add(col);
        print(triggerList.Count);

    }
    void OnTriggerExit2D(Collider2D col)
    {
        triggerList.Remove(col);

    }
}
