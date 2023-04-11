using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleScared : State
{
    public EnemyRangedMovement enemyRangedMovement;
    public BeetleExposed beetleExposed;
    public EnemyHealth enemyHealth;

    public override State RunCurrentState()
    {
        if(enemyHealth.currentHealth <= 1)
        {
            return beetleExposed;
        }
        else
        {
            enemyRangedMovement.speed = 6;
            enemyRangedMovement.startTimeBetweenShots = .5f;
            return this;
        }
    }
}
