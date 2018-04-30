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
    public Camera mainCamera;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
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
        mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        
    }


    public void IsPossessed(bool _possessed)
    {
        possessed = _possessed;
    }

}
