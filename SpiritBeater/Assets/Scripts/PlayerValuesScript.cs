using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValuesScript : MonoBehaviour {

    // Use this for initialization
    public float playerHealth = -1;
    public float money = 0;
    

    public enum PlayerState
    {
        Idle,
        Attacking
    }
    public enum PlayerbehavourState
    {
        Hidden,
        Suspicious
    }
    public PlayerState playerState;
    public PlayerbehavourState behaveState;
	void Start () {
        playerState = PlayerState.Idle;
        behaveState = PlayerbehavourState.Hidden;
	}
	
	// Update is called once per frame
	void Update () {



       
	}
    public void isAttacking()
    {
        playerState = PlayerState.Attacking;
    }
    public void notAttacking()
    {
        playerState = PlayerState.Idle;
    }

    public void isSuspicious()
    {
        behaveState = PlayerbehavourState.Suspicious;
    }
}
