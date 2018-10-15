using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    BoxCollider boxCollider;

    [SerializeField]
    private GameObject deathFx;
    [SerializeField] Transform parent;

    [SerializeField]
    int scorePerHit = 12;

    Scoreboard scoreBoard;

    private void Start()
    {      
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<Scoreboard>();
    }


    private void AddNonTriggerBoxCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fxEffect = Instantiate(deathFx, transform.position, Quaternion.identity);
        fxEffect.transform.parent = parent;
        print("Particles collided with enemy " + gameObject.name);
        //Score hit foe enemy
        scoreBoard.ScoreHit(scorePerHit);
        Destroy(this.gameObject);
       
    }
}
