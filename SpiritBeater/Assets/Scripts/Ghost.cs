using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent2D nav;
    private AnimationManager emotions;
    private AudioSource speaker;
    public AudioClip scream_sfx; // <---------- dont have a sound effect?
    private Rigidbody2D rig;

    //GameObjects required by ghosts
    private GameObject FOV = null;
    private GameObject[] terminalList;
    private GameObject suspiciousSpirit;
    public GameObject playerSpirit;

    // wait times at terminals variables
    float ogTerminalWaitTime;
    private float terminalWaitTime = 2f;
    private float homeTime = 5f;
    public float currentTime = 0f;

    public bool moveTarget = false;
    public bool timerActive = false;
    public Vector3 idleDest;
    int previousPosition;
    private bool possessed = false;
    
    private bool screamed = false;

    private Vector3 huntedPos;

    
    int maxTime;
    int minTime;
    public float timer = 0.0f;

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
        speaker = GetComponent<AudioSource>();
        FOV = GetComponentInChildren<SpiritView>().gameObject;
        nav = GetComponent<NavMeshAgent2D>();
        rig = GetComponent<Rigidbody2D>();
        emotions = GetComponent<AnimationManager>();

        // fill with terminals, for navigation between them
        terminalList = GameObject.FindGameObjectsWithTag("terminal");
        terminals.AddRange(terminalList);

        //sets initial random target terminal for spirits
        int i = Random.Range(0, terminals.Count);
        previousPosition = i;
        idleDest = terminals[i].transform.position;

        spiritState = SpiritState.Idle;

        ogTerminalWaitTime = terminalWaitTime;
    }

    void Update()
    {
        FindPlayer();
        SetTerminalStayLength();
        SetSpiritEmotion();

        // set to true once spirit has stayed at the terminal for a set time length, 
        // determined by SetTerminalStayLength()...
        if (moveTarget)
        {
            SetTarget();
            moveTarget = false;
        }
        Move();        
    }

    void Move()
    {
        timer += Time.deltaTime;

        if (timer >= 0.05f)
        {
            FOVRotation();
            timer = 0;
        }
        //spiritList = GameObject.FindGameObjectsWithTag("Spirit");
        switch (spiritState)
        {
            // travel between terminals
            case SpiritState.Idle:
                nav.destination = idleDest;
                break;

           // move towards the player
            case SpiritState.Attack:                
                if (playerSpirit != null)
                {
                    huntedPos = playerSpirit.transform.position;
                }
                else
                {
                    spiritState = SpiritState.Idle;
                    break;
                }
                nav.destination = huntedPos;                               
                break;

            // stand still???
            case SpiritState.Suspicious:
                nav.destination = transform.position;
                break;
        }
    }

    private void SetSpiritEmotion()
    {
        switch (spiritState)
        {
            case SpiritState.Idle:
                emotions.SetEmotion(Emotions.NORMAL);
                break;

            case SpiritState.Attack:
                emotions.SetEmotion(Emotions.ANGRY);
                break;

            case SpiritState.Suspicious:
                emotions.SetEmotion(Emotions.SAD);
                break;
        }
    }

    // determines how long ghosts should stay at a terminal
    //also, sets moveTarget to true, allowing the ghost to set new target, when the time limit is reached
    private void SetTerminalStayLength()
    {
        if (timerActive)
        {
            // if returning to home terminal (terminal[5]) then stay there for longer, seems to always be grave 2
            if (idleDest == terminals[5].transform.position)
            {
                terminalWaitTime = homeTime;
            }
            // if the ghost has stayed at the terminal for long enough, then set a new target
            // and reset timer
            if (currentTime >= terminalWaitTime)
            {
                moveTarget = true;
                timerActive = false;
                currentTime = 0f;
            }
            currentTime += Time.deltaTime;
            terminalWaitTime = ogTerminalWaitTime;
        }
    }

    //finds the players spirit, if a spirit
    private void FindPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerSpirit = GameObject.FindGameObjectWithTag("Player");            
        }
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

    //if ghost collides with terminal, enter
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == terminals[previousPosition])
        {
            timerActive = true;            
        }
    }

    public bool GetIsHome()
    {
        return isHome;
    }

    public void SetIsHome(bool home)
    {
        isHome = home;
    }

    //set new target and sets previous position to the new target
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

    public void IsSuspicious()
    {
        spiritState = SpiritState.Suspicious;
        emotions.SetEmotion(Emotions.SCARED);
    }
    public void IsAttacking()
    {
        spiritState = SpiritState.Attack;
        if (!screamed)
        {
            MusicMode musicSetting = (MusicMode)PlayerPrefs.GetInt("Music", 0);
            switch (musicSetting)
            {
                case MusicMode.FULL:
                    speaker.volume = 1.0f;
                    break;
                case MusicMode.MUTE:
                    speaker.volume = 0f;
                    break;
                case MusicMode.HALF:
                    speaker.volume = 0.5f;
                    break;
            }
            speaker.PlayOneShot(scream_sfx);
            screamed = true;
        }
    }

    public void IsIdle()
    {
        spiritState = SpiritState.Idle;
        screamed = false;
    }
}