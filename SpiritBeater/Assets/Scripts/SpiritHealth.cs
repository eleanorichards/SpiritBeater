using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiritHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth;
	public GameObject healthBar;
	public Dollah dollah;


	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		//debug, runs decrease health every second
		//InvokeRepeating ("DecreaseHealth", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
        float calculateHealth = currentHealth / maxHealth;
        SetHealthBar(calculateHealth);

    }

	public void DecreaseHealth()
	{
		currentHealth -= 2f;
        if(this.gameObject.tag == "Player Spirit")
        {
            if(currentHealth == 0f)
            {
                //End Game Procedures
                Debug.Log("Player Died");
               
            }
                
            
        }
        else
        {
            dollah.IncreaseCombo();
        }
		
		//scales numbers for healthbar
		float calculateHealth = currentHealth / maxHealth;
		SetHealthBar (calculateHealth);
	}

	public void SetHealthBar(float health)
	{
        if(this.gameObject.tag == "Player")
        {
            healthBar.transform.localScale = new Vector3(health*5, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
        else
        {
            healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
		
	}

    public float getHealth()
    {
        return currentHealth;
    }
}
