using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskSummon : Node
{
    public GameObject[] enemies;
    public Transform[] summon;
    public float summonCountdown;
    public TaskSummon (Transform[] waypoints)
    {
        summon = waypoints;
    }
    public override NodeState Evaluate()
    {
        summonCountdown -= Time.deltaTime;

        //If countdown = 0
        if (summonCountdown == 0)
        {
            //Instantiate enemies
            Instantiate(enemies, waypoints);
        }
    }

    public override NodeState Evaluate()
    { }

}