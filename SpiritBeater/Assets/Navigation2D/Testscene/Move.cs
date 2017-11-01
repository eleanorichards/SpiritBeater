using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButton(0)) {
            print("now");
            Vector3 w = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<NavMeshAgent2D>().destination = w;
        }
    }
}