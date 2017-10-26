using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;
    
    public float targetTime = 1f;
    public float currentTime = 0f;
    public bool moveTarget = false;
    public bool timerActive = false;
    public Vector3 idleDest;
    int previousPosition;

    int maxTime;
    int minTime;

    bool idle = true;
    bool isHome = true;

    public List<GameObject> terminals = new List<GameObject>();

    void Start()
    {
        int i = Random.Range(0, terminals.Count);
        previousPosition = i;
        idleDest = terminals[i].transform.position;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= targetTime)
            {
                moveTarget = true;
                timerActive = false;
                currentTime = 0f;
            }
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
        if (idle == true)
        {
            GetComponent<NavMeshAgent2D>().destination = idleDest;
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

        while (previousPosition == i)
        {
            i = Random.Range(0, terminals.Count);
        }
        idleDest = terminals[i].transform.position;
        previousPosition = i;
    }
}