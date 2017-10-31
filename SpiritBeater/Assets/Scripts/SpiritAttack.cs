using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAttack : MonoBehaviour {

    private Collider2D[] colStore;

    private SpiritView spiritView;
    private float time = 0.0f;
    private float timeBetweenPunches = 1.0f;
    //private Ghost.SpiritState spirState;
	// Use this for initialization
	void Start () {
        time = Time.deltaTime;
        spiritView = GetComponentInChildren<SpiritView>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Ghost>().spiritState == Ghost.SpiritState.Attack)
        {
            time += Time.deltaTime;
            colStore = spiritView.spiritsInRadius;
            foreach (Collider2D Spirit in colStore)
            {
                if (Spirit.gameObject.CompareTag("Player"))
                {
                    if (time >= timeBetweenPunches)
                    {
                        time = 0.0f;
                        Spirit.gameObject.GetComponent<SpiritHealth>().DecreaseHealth();
                    }

                }
            }
        }
	}
}
