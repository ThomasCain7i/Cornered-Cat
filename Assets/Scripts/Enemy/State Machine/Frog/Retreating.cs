using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Run away, can be hit
public class Retreating : State
{
    public PhaseState phaseState;
    public FrogUlt frogUlt;
    public EnemyHealth enemyHealth;
    public float returnToPhase = 10f;
    public float startPhaseTimer = 10f;


    public override State RunCurrentState()
    {
        returnToPhase -= Time.deltaTime;

        if (returnToPhase <= 0)
        {
            returnToPhase = startPhaseTimer;
            return phaseState;
        }
        else
        {
            return this;
        }
    }
}