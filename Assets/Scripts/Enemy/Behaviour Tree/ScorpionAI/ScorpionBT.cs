using System;
using System.Collections.Generic;
using BehaviourTree;

public class ScorpionBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 15f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckHealthBelow(),
                new TaskSpeed(),
                new TaskPatrol(transform, waypoints),
            }),
            new TaskPatrol(transform, waypoints),
        });
        return root;
    }
}