using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiritHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 100f;
	public GameObject healthBar;
	public Dollah dollah;
    public ParticleSystem dollahParticles;


	// Use this for initialization
	void Start ()
	{
		//currentHealth = maxHealth;
		//debug, runs decrease health every second
		//InvokeRepeating ("DecreaseHealth", 1f, 1f);

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
		currentHealth -= 20f;
        if(this.gameObject.tag == "Player")
        {
            if(currentHealth == 0f)
            {
                //End Game Procedures
                Debug.Log("Player Died");
                SceneManager.LoadScene(1);

               
            }
                
            
        }
        else
        {
            //dollah.IncreaseCombo();
            if(currentHealth == 0f)
            {
                Instantiate(dollahParticles, gameObject.transform.position, Quaternion.identity);
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
