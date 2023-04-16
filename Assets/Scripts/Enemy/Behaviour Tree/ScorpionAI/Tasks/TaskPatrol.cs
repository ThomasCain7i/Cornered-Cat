using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskPatrol : Node
{
    [SerializeField]
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;

    private float waitTime = 1f; // in seconds
    private float waitCounter = 0f;
    private bool waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;

        waypoints[0] = GameObject.Find("Waypoint").transform;
        waypoints[1] = GameObject.Find("Waypoint (1)").transform;
        waypoints[2] = GameObject.Find("Waypoint (2)").transform;
        waypoints[3] = GameObject.Find("Waypoint (3)").transform;
        waypoints[4] = GameObject.Find("Waypoint (4)").transform;
        waypoints[5] = GameObject.Find("Waypoint (5)").transform;
        waypoints[6] = GameObject.Find("Waypoint (6)").transform;
        waypoints[7] = GameObject.Find("Waypoint (7)").transform;
        waypoints[8] = GameObject.Find("Waypoint (8)").transform;
        waypoints[9] = GameObject.Find("Waypoint (9)").transform;
        waypoints[10] = GameObject.Find("Waypoint (10)").transform;
        waypoints[11] = GameObject.Find("Waypoint (11)").transform;
        waypoints[12] = GameObject.Find("Waypoint (12)").transform;
        waypoints[13] = GameObject.Find("Waypoint (13)").transform;
        waypoints[14] = GameObject.Find("Waypoint (14)").transform;
        waypoints[15] = GameObject.Find("Waypoint (15)").transform;
        waypoints[16] = GameObject.Find("Waypoint (16)").transform;
        waypoints[17] = GameObject.Find("Waypoint (17)").transform;
        waypoints[18] = GameObject.Find("Waypoint (18)").transform;
        waypoints[19] = GameObject.Find("Waypoint (19)").transform;
        waypoints[20] = GameObject.Find("Waypoint (20)").transform;
        waypoints[21] = GameObject.Find("Waypoint (21)").transform;
        waypoints[22] = GameObject.Find("Waypoint (22)").transform;
        waypoints[23] = GameObject.Find("Waypoint (23)").transform;
        waypoints[24] = GameObject.Find("Waypoint (24)").transform;
        waypoints[25] = GameObject.Find("Waypoint (25)").transform;
        waypoints[26] = GameObject.Find("Waypoint (26)").transform;
        waypoints[27] = GameObject.Find("Waypoint (27)").transform;
        waypoints[28] = GameObject.Find("Waypoint (28)").transform;
        waypoints[29] = GameObject.Find("Waypoint (29)").transform;
        waypoints[30] = GameObject.Find("Waypoint (30)").transform;
        waypoints[31] = GameObject.Find("Waypoint (31)").transform;
        waypoints[32] = GameObject.Find("Waypoint (32)").transform;
        waypoints[33] = GameObject.Find("Waypoint (33)").transform;
        waypoints[34] = GameObject.Find("Waypoint (34)").transform;
        waypoints[35] = GameObject.Find("Waypoint (35)").transform;
        waypoints[36] = GameObject.Find("Waypoint (36)").transform;
    }

    public override NodeState Evaluate()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                waiting = false;
            }
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _transform.position = Vector2.MoveTowards(_transform.position, wp.position, ScorpionBT.speed * Time.deltaTime);
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}