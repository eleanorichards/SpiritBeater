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
    private AnimationManager emotions;

    private Vector3 huntedPos;


    private GameObject suspiciousSpirit;
    private GameObject[] spirList;
    private Rigidbody2D rig;
    int maxTime;
    int minTime;
    public float timer = 0.0f;

    private GameObject[] playList;
    private bool Updatebool = true;


    private Vector2 dist = new Vector2();
    private Vector2 distprevframe = new Vector2();
    private Vector2 dir = new Vector2();

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
        spirList = GameObject.FindGameObjectsWithTag("Spirit");
        spiritState = SpiritState.Idle;
        FOV = GetComponentInChildren<SpiritView>().gameObject;
        nav = GetComponent<NavMeshAgent2D>();
        rig = GetComponent<Rigidbody2D>();
        GameObject[] terminalList = GameObject.FindGameObjectsWithTag("terminal");
        terminals.AddRange(terminalList);

        int i = Random.Range(0, terminals.Count);
        previousPosition = i;
        idleDest = terminals[i].transform.position;
        emotions = GetComponent<AnimationManager>();
        OGtargetTime = terminalTime;
    }

    void Update()
    {
        if (Updatebool == true && GameObject.FindGameObjectWithTag("Player") != null)
        {
            playList = GameObject.FindGameObjectsWithTag("Player");
            Updatebool = false;
        }
        if (timerActive)
        {

            //if returning to home terminal (terminal[5]) then stay for longer
            if (idleDest == terminals[5].transform.position)
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
        //  }
    }

    void Move()
    {
        timer += Time.deltaTime;

        if (timer >= 0.05f)
        {
            FOVRotation();
            timer = 0;
        }

        switch (spiritState)
        {
            case SpiritState.Idle:
                nav.destination = idleDest;
                emotions.SetEmotion(Emotions.NORMAL);
                break;
            case SpiritState.Attack:
                foreach (GameObject obj in spirList)
                {
                    foreach (GameObject playObj in playList)
                    {
                        if (playObj != null)
                        {
                            huntedPos = playObj.transform.position;
                        }

                        else
                        {
                            spiritState = SpiritState.Idle;
                            break;
                        }
                    }
                }
                foreach (GameObject obj in spirList)
                {
                    if (obj != null && obj.GetComponent<Ghost>().spiritState != Ghost.SpiritState.Suspicious)
                    {
                        nav.destination = huntedPos;
                    }
                }
                break;
        }

        //if (idle == true)
        //    {
        //        GetComponent<NavMeshAgent2D>().destination = idleDest;
        //    }
        //    else if (idle == false)
        //    {
        //        GetComponent<NavMeshAgent2D>().destination = player.transform.position;
        //    }


    }

    void FOVRotation()
    {

        dist = FOV.transform.position;
        dir = dist - distprevframe;
        dir = dir * 90;
        distprevframe = FOV.transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        FOV.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == terminals[previousPosition])
        {
            timerActive = true;
            
        }
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
        if (previousPosition == i)
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

    public void isSuspicious()
    {
        spiritState = SpiritState.Suspicious;
        emotions.SetEmotion(Emotions.SCARED);
    }
    public void isAttacking()
    {
        spiritState = SpiritState.Attack;
        emotions.SetEmotion(Emotions.ANGRY);
    }
}