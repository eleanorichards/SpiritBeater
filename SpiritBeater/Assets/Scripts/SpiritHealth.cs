using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiritHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 100f;
	public GameObject healthBar;
    private GameObject player;
	private Dollah dollah;
    public ParticleSystem dollahParticles;
    private AnimationManager emotions;


	// Use this for initialization
	void Start ()
	{
        //currentHealth = maxHealth;
        //debug, runs decrease health every second
        //InvokeRepeating ("DecreaseHealth", 1f, 1f);


        player = GameObject.FindGameObjectWithTag("MasterPlayer");
        dollah = player.GetComponent<Dollah>();
        emotions = GetComponent<AnimationManager>();

	}

    void Awake()
    {
       // currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        float calculateHealth = currentHealth / maxHealth;
        SetHealthBar(calculateHealth);

    }

	public void DecreaseHealth()
	{

        if(this.gameObject.tag == "Player")
        {
		currentHealth -= 10f;
            if(currentHealth <= 0f)
            {
                //End Game Procedures
                Debug.Log("Player Died");
                SceneManager.LoadScene(1);

               
            }
                
            
        }
        else
        {
            currentHealth -= 30.0f;
            dollah.IncreaseCombo();
            emotions.SetEmotion(Emotions.SAD);
            if(currentHealth <= 0f)
            {
                Instantiate(dollahParticles, gameObject.transform.position, Quaternion.identity);
                dollah.AddDollah(false);
                Debug.Log("Spirit Died");
                Destroy(gameObject);
            }
        }
		
		//scales numbers for healthbar
		float calculateHealth = currentHealth / maxHealth;
		SetHealthBar (calculateHealth);
	}

	public void SetHealthBar(float health)
	{
        
            healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        
		
	}

    public float getHealth()
    {
        return currentHealth;
    }
}
