using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    Text scoreText;
    private int score;

    private void Awake()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }
    // Use this for initialization
    void Start ()
    {     
        scoreText.text = score.ToString();

    }
	
	// Update is called once per frame
    public void ScoreHit(int scorePerHit)
    {
        //END restore testing with GIT
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
    public void TimeHit(int scoreForTime)
    {
        score += scoreForTime;
        scoreText.text = score.ToString();
    }


}
