using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritView : MonoBehaviour
{

    public float max_view_angle = 110.0f;
    Vector2 ray_direction = Vector2.zero;

    public float view_radius = 5.0f;
    [Range(0,360)]
    public float view_angle;

    public LayerMask ignoreMask; //Layers to ignore when raycasting
    public LayerMask acceptMask; //anything you want to return in the view radius
    private LayerMask me = 10;
    private GameObject parent;
    //[HideInInspector]
    public List<GameObject> spirits = new List<GameObject>(100);
   
    // Use this for initialization
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        FOVCast();
    }

    private void FOVCast()
    {
        //any spiritsInRadius are in the circle
        Collider2D[] spiritsInRadius = Physics2D.OverlapCircleAll(transform.position, view_radius, acceptMask);
        spirits.Clear();
        //myself.layer = 10;
        foreach (Collider2D spirit in spiritsInRadius)
        {
            Debug.Log(spirit.name);
            Transform target = spirit.transform;
            Vector3 ray_direction = (spirit.transform.position - transform.position);
            //find angle between my agent and the hit is it in my field of view
            if (Vector3.Angle(transform.forward, ray_direction) < view_angle/* /2*/)
            {
                //this is inside the view angle
                if (!Physics2D.Raycast(transform.position, ray_direction, 50.0f, me))
                {
                    //if player found
                   // parent.GetComponent<Ghost>().spiritState = Ghost.SpiritState.Attack;
                    //if(!player.stealth())
                    //warn all spiritsInRadius
                    //send to Ghost
                    if(!spirits.Contains(target.gameObject) && target.gameObject != gameObject.transform.parent)
                    spirits.Add(target.gameObject);
                    Debug.DrawLine(transform.position, target.transform.position, Color.red);
                }

            }         
        }
        //myself.layer = 9;

    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }


    
    //if(hit.collider.gameObject.CompareTag("Spirit"))
    //{
    //    Debug.DrawLine(transform.position, ray_direction.normalized, Color.red);
    //    print("Spirit in sight");
    //}          
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Spirit"))
    //    {
    //        spirits.Add(col.gameObject);
    //        print("Spirit added to list: " + col.gameObject.name);
    //    }
    //}


    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.CompareTag("Spirit"))
    //    {
    //        for (int i = spirits.Count; i >= 0; i--)
    //        {
    //            print("Spirit removed from list: " + col.gameObject.name);
    //            spirits.RemoveAt(i);
    //        }
    //    }
    //}

}