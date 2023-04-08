using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Run away, can be hit
public class Retreating : State
{
    public FrogUlt frogUlt;
    public bool isInAttackRange;

    //Retreating
    public Rigidbody2D rb;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    //Shooting
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;
    public Transform player;



    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return frogUlt;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            return this;
        }
    }
}