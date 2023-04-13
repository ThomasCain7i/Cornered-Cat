using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskSpeed : Node
{
    public static float speedChange = 5f;

    public override NodeState Evaluate()
    {
        speedChange = Time.deltaTime;
        if(speedChange > 4)
        {
            Debug.Log("Speed = 25");
            SlugBT.speed = 25f;
            if (speedChange > 3)
            {
                Debug.Log("Speed = 15");
                SlugBT.speed = 15f;
                if (speedChange > 2)
                {
                    Debug.Log("Speed = 30");
                    SlugBT.speed = 30f;
                    if (speedChange > 1)
                    {
                        Debug.Log("Speed = 20");
                        SlugBT.speed = 20f;
                        if (speedChange <= 0)
                        {
                            speedChange = 5;
                        }
                    }
                }
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

}