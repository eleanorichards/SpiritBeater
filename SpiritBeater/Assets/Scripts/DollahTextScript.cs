using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollahTextScript : MonoBehaviour {

    public float score;
    public GameObject player;
    public GameObject scoreText;
    public GameObject devilText;
    private GameObject canvas;
    private bool showMessage = true;
    private float timer = 0;
    private Dollah dollah;

    // Use this for initialization
    void Start ()
    {
        scoreText = GameObject.FindWithTag("Score");
        devilText = GameObject.FindWithTag("DevilMessage");
        devilText.GetComponent<Text>().transform.position = new Vector2(0, 1000);
        canvas = GameObject.FindWithTag("Canvas");
        dollah = player.GetComponent<Dollah>();

    }

    // Update is called once per frame
    void Update ()
    {        
        score = player.GetComponent<Dollah>().DollahScore;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString() + " / " + dollah.goldDebtDue.ToString();

        DevilMessage();
       
	}

    private void DevilMessage()
    {
        if (player.GetComponent<Dollah>().DollahScore < -100f)
        {
            if (showMessage == true)
            {
                timer += Time.deltaTime;
                if (timer < 5f)
                {
                    devilText.transform.position = canvas.transform.position;
                }
                else
                {
                    devilText.transform.position = new Vector2(0, 1000);
                    showMessage = false;

                }
            }
        }
        else if (player.GetComponent<Dollah>().DollahScore > 0f)
        {
            showMessage = true;
            timer = 0f;
        }
    }
}
