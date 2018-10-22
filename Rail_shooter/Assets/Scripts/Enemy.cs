using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    BoxCollider boxCollider;

    [SerializeField] private GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int health = 10;


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
        ProccesHit();

        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void ProccesHit()
    {
        //Score hit foe enemy
        scoreBoard.ScoreHit(scorePerHit);
        //todo consider hit FX
        health = health - 1;
    }

    private void KillEnemy()
    {
        GameObject fxEffect = Instantiate(deathFx, transform.position, Quaternion.identity);
        fxEffect.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
