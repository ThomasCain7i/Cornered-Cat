using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Become invulnerable
public class PhaseState : State
{
    public float phaseCountdown = 10f;
    public float startPhaseCountdown = 10f;
    public Retreating retreating;

    public override State RunCurrentState()
    {
        //10 seconds
        phaseCountdown -= Time.deltaTime;

        if (phaseCountdown <= 0)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            phaseCountdown = startPhaseCountdown;
            return retreating;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            return this;
        }
    }
}