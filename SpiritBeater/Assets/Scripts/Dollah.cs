﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dollah : MonoBehaviour {

	public float DollahScore = 0;
	public int Combo = 0;
	public float ComboMultiplier = 1.0f;
	private int increment = 50;
	private int stealthIncrement = 100;


	public void AddDollah(bool isStealth)
	{
		if (isStealth) {
			DollahScore += (ComboMultiplier * stealthIncrement);
		} else {
			DollahScore += (ComboMultiplier * increment);
		}
	}


	public void IncreaseCombo()
	{
		Combo++;
		if (Combo < 10) {
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
	void Update () {
		
	}
}
