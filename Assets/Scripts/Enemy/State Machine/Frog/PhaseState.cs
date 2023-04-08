using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Become invulnerable
public class PhaseState : State
{
    public float phaseCountdown = 10f;
    public Retreating retreating;

    public override State RunCurrentState()
    {
        //10 seconds
        phaseCountdown -= Time.deltaTime;

        if(phaseCountdown <= 0)
        {
            return retreating;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
            return this;
        }
    }
}
