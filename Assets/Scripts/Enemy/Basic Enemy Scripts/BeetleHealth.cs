using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleHealth : State
{
    public EnemyRangedMovement enemyRangedMovement;
    public BeetleEnraged beetleEnraged;
    public EnemyHealth enemyHealth;

    public override State RunCurrentState()
    {
        if (this.enemyHealth.currentHealth <= 40)
        {
            return beetleEnraged;
        }
        else
        {
            this.enemyRangedMovement.speed = 3;
            this.enemyRangedMovement.startTimeBetweenShots = 2;
            return this;
        }
    }
}
