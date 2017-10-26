using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour {

	public Transform destinationOne;
	public Transform destinationTwo;
	public Transform destinationThree;
	public Transform player;

	public Vector3 idleDest;

	bool idle = true;

	// Use this for initialization
	void Start () {
		idleDest = destinationOne.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

}

	void Move()
	{
		if (idle == true) {
			GetComponent<NavMeshAgent2D> ().destination = idleDest;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (idleDest == destinationOne.position) {
			idleDest = destinationTwo.position;
		}
		else if (idleDest == destinationTwo.position) {
			idleDest = destinationThree.position;
		}
		else if (idleDest == destinationThree.position) {
			idleDest = destinationOne.position;
		}
	}
}


