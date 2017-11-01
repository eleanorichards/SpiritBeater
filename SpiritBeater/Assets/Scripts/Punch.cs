using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    private EnemiesInRange range;
    private List<Collider2D> list;
    private float time = 0.0f;
    private float timeBetweenPunches = 0.5f;
    //AUDIO
    private AudioSource audio;
    public AudioClip Player_attack;

    private PlayerValuesScript playState;

    private SpiritHealth health;
    private GameObject enemy;
    // Use this for initialization
    void Start () {
        range = GetComponent<EnemiesInRange>();
        list = range.triggerList;
        time = Time.time;
        playState = gameObject.transform.parent.GetComponent<PlayerValuesScript>();
        audio = GameObject.Find("AudioManager").GetComponentInChildren<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            if (playState.playerState != PlayerValuesScript.PlayerState.Attacking)
            {
                audio.PlayOneShot(Player_attack);
                playState.isAttacking();
            }
            time += Time.deltaTime;
            if (time >= timeBetweenPunches)
            {
                time = 0.0f;
                foreach(Collider2D item in list)
                {
                    if (item != null)
                    {
                        item.gameObject.GetComponent<SpiritHealth>().DecreaseHealth();
                    }
                    
                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            playState.notAttacking();
        }
	}
}
