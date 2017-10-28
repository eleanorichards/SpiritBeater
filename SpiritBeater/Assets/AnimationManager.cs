using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotions {
	NORMAL,
	HAPPY,
	SCARED,
	ANGRY,
	SAD
}

public class AnimationManager : MonoBehaviour {

	public Emotions emotion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetInteger("EmotionState", (int)emotion);

		if(Input.GetKeyDown(KeyCode.Space)){
			switch (emotion) {
			case Emotions.NORMAL:
				emotion = Emotions.HAPPY;
				break;
			case Emotions.HAPPY:
				emotion = Emotions.SCARED;
				break;
			case Emotions.SCARED:
				emotion = Emotions.ANGRY;
				break;
			case Emotions.ANGRY:
				emotion = Emotions.SAD;
				break;
			case Emotions.SAD:
				emotion = Emotions.NORMAL;
				break;
			}
		}
	}

	public void SetEmotion(Emotions newEmotion){
		emotion = newEmotion;
	}
}
