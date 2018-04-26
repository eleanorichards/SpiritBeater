using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritView : MonoBehaviour
{

    Vector2 ray_direction = Vector2.zero;
    //AUDIO
    private AudioSource audio;
    public AudioClip hmm;

    public float view_radius = 5.0f;
    [Range(0, 360)]
    public float view_angle;

    public LayerMask ignoreMask; //Set to spirit and player
    public LayerMask acceptMask; //anything you want to return in the view radius
    public LayerMask acceptMaskTwo;

    public Collider2D[] spiritsInRadius;
    private LayerMask me = 10;
    private GameObject parent;
    //[HideInInspector]
    public List<GameObject> spirits = new List<GameObject>(100);

    // Use this for initialization
    void Start()
    {
        audio = GameObject.Find("Music").GetComponent<AudioSource>();
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
        spirits.Clear();
        acceptMask += acceptMaskTwo;
        spiritsInRadius = Physics2D.OverlapCircleAll(transform.position, view_radius, acceptMask);
        //myself.layer = 10;
        foreach (Collider2D spirit in spiritsInRadius)
        {

            Transform target = spirit.transform;
            Vector3 ray_direction = (spirit.transform.position - transform.position);
            //find angle between my agent and the hit is it in my field of view
            if (Vector3.Angle(transform.up, ray_direction) < view_angle /2)
            {
                //this is inside the view angle
                if (!Physics2D.Raycast(transform.position, ray_direction, 50.0f, me))
                {
                    if (spirit.CompareTag("Player"))
                    {
                        if (spirit.gameObject.GetComponent<PlayerValuesScript>().playerState == PlayerValuesScript.PlayerState.Attacking)
                        {
                            spirit.gameObject.GetComponent<PlayerValuesScript>().isSuspicious();
                        }
                        if (spirit.gameObject.GetComponent<PlayerValuesScript>().behaveState == PlayerValuesScript.PlayerbehavourState.Suspicious)
                        {
                            audio.PlayOneShot(hmm);
                            gameObject.transform.parent.GetComponent<Ghost>().IsAttacking();
                        }
                            //if(spirit.GetComponent<Attack_Script>().IsAttacking())
                            //{                           
                            //i'm not sure if states are actually working...
                            //this.parent.GetComponent<Ghost>().spiritState = Ghost.SpiritState.Attack;
                            //}
                            Debug.DrawLine(transform.position, target.transform.position, Color.green);

                    }
                    if (spirit.CompareTag("Spirit"))
                    {
                        if (spirit.gameObject.GetComponent<Ghost>().spiritState == Ghost.SpiritState.Suspicious)
                        {
                            gameObject.transform.parent.GetComponent<Ghost>().IsAttacking();
                        }
                    }
                    //else if (spirit.CompareTag("Spirit"))
                    //{
                    //    if (spirit.gameObject.GetComponent<Ghost>().spiritState == Ghost.SpiritState.Suspicious)
                    //    {
                    //        print("suspicious");
                    //    }
                    //}
                    //else
                    //{
                    //    Debug.DrawLine(transform.position, target.transform.position, Color.red);

                    //}
                                      
                    if (!spirits.Contains(target.gameObject) && target.gameObject != gameObject.transform.parent)
                    {
                        spirits.Add(target.gameObject);
                    }
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




}