using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    private EnemiesInRange range;
    private List<Collider2D> list;
    private float time = 0.0f;
    private float timeBetweenPunches = 1.0f;

    private GameObject enemy;
    // Use this for initialization
    void Start () {
        range = GetComponent<EnemiesInRange>();
        list = range.triggerList;
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
                foreach(Collider2D item in list)
                {
                    item.gameObject.GetComponent<SpiritHealth>().DecreaseHealth();
                }
            }

        }
	}
}
