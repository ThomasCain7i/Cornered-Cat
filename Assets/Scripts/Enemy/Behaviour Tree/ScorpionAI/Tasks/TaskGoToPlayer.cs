using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskSpeed : Node
{
    public static float speedChange = 5f;

    public override NodeState Evaluate()
    {


        state = NodeState.RUNNING;
        return state;
    }

}