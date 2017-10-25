using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour {

	public Transform destinationOne;
	public Transform destinationTwo;
	public Transform destinationThree;

	public Vector3 dest;

	// Use this for initialization
	void Start () {
		dest = destinationOne.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
}

	void Move()
	{
		if (dest == destinationOne.position) {
			GetComponent<NavMeshAgent2D> ().destination = dest;
			print ("one");

		}
		if (dest == destinationTwo.position) {
			GetComponent<NavMeshAgent2D> ().destination = dest;	
			print ("two");
		} 
		if (dest == destinationThree.position) {
			GetComponent<NavMeshAgent2D> ().destination = dest;	
			print ("three");
		}		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (dest == destinationOne.position) {
			dest = destinationTwo.position;
		}
		else if (dest == destinationTwo.position) {
			dest = destinationThree.position;
		}
		else if (dest == destinationThree.position) {
			dest = destinationOne.position;
		}
	}
}


