using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

    [Tooltip ("In ms^-1")][SerializeField]
    float Speed = 10f;
    [SerializeField][Range(0,15)][Tooltip("In m")]
    float Xrange = 7.2f;
    [SerializeField] [Range(0, 15)][Tooltip("In m")]
    float yMin = 4f;
    [SerializeField] [Range(0, 15)][Tooltip("In m")]
    float yMax = 4.17f;

    [SerializeField] float positionPitchFactor = -6f;// wspolczynnik pochylenia w zaleznosci od odleglosci od srodka obrazu 
    [SerializeField] float controlPitchFactor = -10f;           // wspolczynnik zwiekszenia pochylenia w zaleznosci od nacisnienia guzika ruchu 
    [SerializeField] float positionYawFactor = 7f;
    [SerializeField] float controlRollFactor = -14f;

    float xThrow, yThorw;

    // Use this for initialization
    void Start ()
    {
		



	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
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
        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThorw * Speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        var newLocalPositionX = Mathf.Clamp(rawNewXPos, -Xrange, Xrange);
        var newLocalPositionY = Mathf.Clamp(rawNewYPos, -yMin, yMax);

        transform.localPosition = new Vector3(newLocalPositionX, newLocalPositionY, transform.localPosition.z);
    }
}
