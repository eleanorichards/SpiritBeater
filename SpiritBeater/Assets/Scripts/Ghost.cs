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
    private NavMeshAgent2D nav;

    int maxTime;
    int minTime;

    //if idle work, if not go to player
    bool idle = true;
    bool isHome = true;


    public enum SpiritState 
    {
        Idle,
        Suspicious,
        Attack
    }

    public SpiritState spiritState;

    public List<GameObject> terminals = new List<GameObject>();

    void Start()
    {
        spiritState = SpiritState.Idle;
        FOV = GameObject.Find("FOV");
        nav = GetComponent<NavMeshAgent2D>();
        int i = Random.Range(0, terminals.Count);
        previousPosition = i;
        idleDest = terminals[i].transform.position;
        OGtargetTime = terminalTime;
    }

    void Update()
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

    void Move()
    {
        switch(spiritState)
        {
            case SpiritState.Idle:
                nav.destination = idleDest;
                break;
            case SpiritState.Attack:
                nav.destination = player.transform.position;
                break;
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