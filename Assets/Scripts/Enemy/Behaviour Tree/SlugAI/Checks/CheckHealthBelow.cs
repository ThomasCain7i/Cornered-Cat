using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class CheckHealthBelow : Node
{
    public EnemyHealth enemyHealth;

    public override NodeState Evaluate()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

            if (enemyHealth.currentHealth <25)
            {
            //In therory go to next
                state = NodeState.SUCCESS;
                return state;
            }

            //Stay here?
            state = NodeState.FAILURE;
            return state;
    }
}