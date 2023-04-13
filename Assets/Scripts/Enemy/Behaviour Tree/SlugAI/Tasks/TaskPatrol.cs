using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskPatrol : Node
{
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

        waypoints[0] = GameObject.Find("Waypoint(1)").transform;
        waypoints[1] = GameObject.Find("Waypoint(2)").transform;
        waypoints[2] = GameObject.Find("Waypoint(3)").transform;
        waypoints[3] = GameObject.Find("Waypoint(4)").transform;
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
                _transform.position = Vector2.MoveTowards(_transform.position, wp.position, SlugBT.speed * Time.deltaTime);
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}