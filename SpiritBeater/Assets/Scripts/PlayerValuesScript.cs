using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerValuesScript : MonoBehaviour {

    // Use this for initialization
    public float playerHealth = -1;
    public float money = 0;
    private int SeenMeter = 0;
    private float time = 0.0f;
    private float timeToHide = 1.0f;
    public int numofAngryGhosts = 0;
    private List<Collider2D> listholder;
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
    public GameObject list;
	void Start () {
        playerState = PlayerState.Idle;
        behaveState = PlayerbehavourState.Hidden;
    }
	
	// Update is called once per frame
	void Update () {
        if (listholder != null)
        listholder = list.GetComponent<EnemiesInRange>().triggerList;
        if (money >= 100)
        {
            SceneManager.LoadScene(3);
        }
        if (behaveState == PlayerbehavourState.Suspicious)
        {
            if (listholder != null)
            {
                for (int i = 0; i != listholder.Count; i++)
                {
                    if (listholder[i].GetComponent<Ghost>().spiritState == Ghost.SpiritState.Suspicious || listholder[i].GetComponent<Ghost>().spiritState == Ghost.SpiritState.Attack)
                    {
                        numofAngryGhosts++;
                    }
                }
                if (numofAngryGhosts == 0)
                {
                    time += Time.deltaTime;
                    if (time >= timeToHide)
                    {
                        behaveState = PlayerbehavourState.Hidden;
                        time = 0;
                    }
                }
            }
        }

       
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
        time = 0.0f;
    }
}
