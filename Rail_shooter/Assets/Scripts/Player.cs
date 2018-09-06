using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

    [Tooltip ("In ms^-1")][SerializeField]
    float Speed = 4f;

	// Use this for initialization
	void Start ()
    {
		



	}
	
	// Update is called once per frame
	void Update ()
    {

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThor = CrossPlatformInputManager.GetAxis("Vertical");
        //make this frame independent
        float xOffset = xThrow * Speed * Time.deltaTime;

        print(xOffset);
	}
}
