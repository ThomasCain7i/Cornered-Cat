using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ghost mode with increased firerate

public class FrogUlt : State
{
    public FrogUlt frogUlt;
    public EnemyHealth enemyHealth;

    public override State RunCurrentState()
    {

        return this;
    }
}
