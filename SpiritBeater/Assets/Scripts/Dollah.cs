using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dollah : MonoBehaviour {

	public float DollahScore = 0;
	public int Combo = 0;
	public float ComboMultiplier = 1.0f;
	private int increment = 50;
	private int stealthIncrement = 100;

	public void AddDollah(bool isStealth, float amount)
	{
		if (isStealth)
        {
            //DollahScore += (ComboMultiplier * stealthIncrement);
            DollahScore += amount;
		}
        else
        {
            //DollahScore += (ComboMultiplier * increment);
            DollahScore += amount;
        }
    }

    public void SubtractDollah(float amountLost)
    {
        DollahScore -= amountLost;
    }


	public void IncreaseCombo()
	{
		Combo++;
		if (Combo > 10) {
			ComboMultiplier += (Combo / 10);
		} else if (Combo >= 10) {
			ComboMultiplier += (Combo / 100);
		}
	}

	public void ResetCombo()
	{
		Combo = 0;
		ComboMultiplier = 1.0f;
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(DollahScore >= 3500)
        {
            SceneManager.LoadScene(3);
        }
	}
}
