using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnraged : State
{
    public EnemyRangedMovement enemyRangedMovement;
    public BeetleScared beetleScared;
    public EnemyHealth enemyHealth;

    public override State RunCurrentState()
    {
        if(enemyHealth.currentHealth <= 30)
        {
            return beetleScared;
        }
        else
        {
            this.enemyRangedMovement.speed = 5;
            this.enemyRangedMovement.startTimeBetweenShots = 1;
            return this;
        }
    }
}
