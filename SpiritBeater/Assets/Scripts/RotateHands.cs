using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHands : MonoBehaviour
{

    Vector3 pos;
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        pos = Camera.main.WorldToScreenPoint(transform.position);
        //LookAtMouse();
        FlipSprite();
    }

    public void LookAtMouse()
    {
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void FlipSprite()
    {
        if (Input.mousePosition.x < Screen.width/2)        
            transform.localScale = new Vector3(-1, 1, 1);            
        
        else if(Input.mousePosition.x > Screen.width/2)        
            transform.localScale = new Vector3(1, 1, 1);          
    }
}
