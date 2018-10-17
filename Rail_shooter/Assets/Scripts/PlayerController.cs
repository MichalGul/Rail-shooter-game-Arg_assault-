using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

    //TODO work out why sometime slow on first play of scenes


    [Header("General")] //header w inspektorze na kategorie
    [Tooltip ("In ms^-1")][SerializeField]
    float controlSpeed = 10f;
    [SerializeField][Range(0,15)][Tooltip("In m")]
    float Xrange = 7.2f;
    [SerializeField] [Range(0, 15)][Tooltip("In m")]
    float yMin = 4f;
    [SerializeField] [Range(0, 15)][Tooltip("In m")]
    float yMax = 4.17f;

    [SerializeField]
    GameObject[] guns;

    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = -6f;// wspolczynnik pochylenia w zaleznosci od odleglosci od srodka obrazu 
    [SerializeField] float controlRollFactor = -14f;

    [Header("Controll-throw based")]
    [SerializeField] float positionYawFactor = 7f;
    [SerializeField] float controlPitchFactor = -10f;// wspolczynnik zwiekszenia pochylenia w zaleznosci od nacisnienia guzika ruchu 

    [Header("Points Gain")]
    [SerializeField]
    float timeToScoreInterval = 10f;
    [SerializeField]
    int scoreForTime = 20;
    Scoreboard scoreBoard;
    float timeToScore = 10.0f;


   

    private void Awake()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    float xThrow, yThorw;
    bool isControlEnabled = true;
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProccesBeingAlive(timeToScoreInterval);
            ProccesFiring();
        }
    }

    private void ProccesFiring()
    {
        
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }

    }

 

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThorw * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float rollDueToControlThrow = xThrow * controlRollFactor;

        float yaw = yawDueToPosition;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

       
    }

    private void ProcessTranslation()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
         yThorw = CrossPlatformInputManager.GetAxis("Vertical");

        //make this frame independent
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThorw * controlSpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        var newLocalPositionX = Mathf.Clamp(rawNewXPos, -Xrange, Xrange);
        var newLocalPositionY = Mathf.Clamp(rawNewYPos, -yMin, yMax);

        transform.localPosition = new Vector3(newLocalPositionX, newLocalPositionY, transform.localPosition.z);
    }

    private void OnPlayerDeath() // called by string reference
    {
        print("Movement disabled caused by player death !");
        isControlEnabled = false;
    }


    private void ProccesBeingAlive(float PointInterval)
    {
        if (Time.time > timeToScore)
        {
            timeToScore += PointInterval;
            ScoreForBeingAlive(scoreForTime);
        }
    }


    private void ScoreForBeingAlive(int points)
    {
        scoreBoard.TimeHit(points);
    }


    private void ActivateGuns()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (var gun in guns)
        {
            gun.SetActive(false);
        }
    }



}
