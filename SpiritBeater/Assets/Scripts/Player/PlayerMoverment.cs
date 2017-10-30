using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{

    public Vector2 velocity;
    public float speed, dragSpeed;
    private bool directionIsLeft;
    public bool possessed = false;
    private Rigidbody2D rig;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (possessed)
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                //dampen velocity
                velocity = new Vector2(
                    Mathf.Lerp(velocity.x, 0, Time.deltaTime * dragSpeed),
                    Mathf.Lerp(velocity.y, 0, Time.deltaTime * dragSpeed));
            }
            else
            {
                velocity.x = Input.GetAxis("Horizontal") * speed;
                velocity.y = Input.GetAxis("Vertical") * speed;
            }

            //move
            //GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);//new Vector2(velocity.x * acceleration, velocity.y * acceleration), ForceMode2D.Impulse);
            rig.velocity = velocity;
            //clamp velocity
            rig.velocity = new Vector2(
            Mathf.Clamp(rig.velocity.x, -speed, speed),
            Mathf.Clamp(rig.velocity.y, -speed, speed));
        }
        //set direction
        //	if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
        //		directionIsLeft = true;
        //		transform.localScale = new Vector3(-1,1,1);
        //	}
        //	if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
        //		directionIsLeft = false;
        //		transform.localScale = new Vector3(1,1,1);
        //	}
        //}

        //public bool GetDirection(){
        //	return directionIsLeft;
        //}
    }


    public void IsPossessed(bool _possessed)
    {
        possessed = _possessed;
    }
}
