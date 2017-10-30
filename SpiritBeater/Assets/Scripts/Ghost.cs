using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;

    private float OGtargetTime;
    public float terminalTime = 2f;
    public float homeTime = 5f;
    public float currentTime = 0f;
    public bool moveTarget = false;
    public bool timerActive = false;
    public Vector3 idleDest;
    int previousPosition;
    private GameObject FOV = null;
    private bool possessed = false;

    int maxTime;
    int minTime;

    //if idle work, if not go to player
    bool idle = true;
    bool isHome = true;

    public List<GameObject> terminals = new List<GameObject>();

    void Start()
    {
        FOV = GameObject.Find("FOV");

        int i = Random.Range(0, terminals.Count);
        previousPosition = i;
        idleDest = terminals[i].transform.position;
        OGtargetTime = terminalTime;
    }

    void Update()
    {
        if (!possessed)
        {
            if (timerActive)
            {
                //if returning to home terminal (terminal[0]) then stay for longer
                if (idleDest == terminals[0].transform.position)
                {
                    terminalTime = homeTime;
                }
                currentTime += Time.deltaTime;
                if (currentTime >= terminalTime)
                {
                    moveTarget = true;
                    timerActive = false;
                    currentTime = 0f;
                }
                terminalTime = OGtargetTime;
            }

            if (moveTarget)
            {
                SetTarget();
                moveTarget = false;
            }
            Move();
        }
    }

    void Move()
    {
        if (GetComponent<PlayerMoverment>().possessed == false)
        {
            if (idle == true)
            {
                GetComponent<NavMeshAgent2D>().destination = idleDest;
            }
            else if (idle == false)
            {
                GetComponent<NavMeshAgent2D>().destination = player.transform.position;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == terminals[previousPosition])
            timerActive = true;
    }

    public bool getIsHome()
    {
        return isHome;
    }

    public void setIsHome(bool home)
    {
        isHome = home;
    }

    void SetTarget()
    {
        int i = Random.Range(0, terminals.Count);

        if (previousPosition != 0)
        {
            i = 0;
        }
        else
        {
            i = Random.Range(0, terminals.Count);
        }
        
        idleDest = terminals[i].transform.position;
        previousPosition = i;
    }


    public void IsPossessed(bool _possessed)
    {
        possessed = _possessed;
    }

}