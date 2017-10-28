using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


	public Animator animator;

	public void StartGame(string scene)
	{
		SceneManager.LoadScene (scene);

	}


	public void QuitGame()
	{
		Application.Quit ();
	}

	public void Controls()
	{

		animator.SetBool ("ControlsUp", !animator.GetBool ("ControlsUp"));


	}


}
