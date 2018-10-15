using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //ok as long as this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour {

    [SerializeField][Tooltip("In seconds")]
    float levelLoadDelay = 2f;
    [Tooltip("FX prefab on player")]
    public GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        
        Debug.Log("Playter triggered");
    }

    private void StartDeathSequence()
    {        
        //Disable player controlls
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("Restart", levelLoadDelay);
    }

    private void Restart() // string referenced
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
