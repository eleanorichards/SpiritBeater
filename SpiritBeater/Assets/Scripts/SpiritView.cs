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

    private LayerMask obstacleMask = 8;
    //[HideInInspector]
    public List<GameObject> spirits = new List<GameObject>(100);
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FOVCast();
    }

    private void FOVCast()
    {
        Collider2D[] spiritsInRadius = Physics2D.OverlapCircleAll(transform.position, view_radius);
        Debug.Log(spiritsInRadius.Length);
        //find angle between my agent and the hit is it in my field of view
        foreach (Collider2D spirit in spiritsInRadius)
        {
            print("searching");
            Transform target = spirit.transform;
            Vector3 ray_direction = (spirit.transform.position - transform.position);
            if(Vector3.Angle(transform.up, ray_direction) < view_angle /2)
            {
                if(!Physics2D.Raycast(transform.position, ray_direction, 50.0f, obstacleMask))
                {
                    spirits.Add(target.gameObject);
                    Debug.DrawLine(transform.position, target.transform.position, Color.red);
                }
            }
           
            
        }

    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }


    //ray_direction = (spirit.transform.position - transform.position).normalized;
    //view_angle = Vector2.Angle(ray_direction, transform.forward);

    //RaycastHit2D hit = Physics2D.Raycast(transform.position, ray_direction.normalized);

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
    //   if (col.CompareTag("Spirit"))
    //    {
    //        for(int i = spirits.Count; i >= 0; i--)
    //        {
    //            print("Spirit removed from list: " + col.gameObject.name);
    //            spirits.RemoveAt(i);
    //        }
    //    }
    //}

}