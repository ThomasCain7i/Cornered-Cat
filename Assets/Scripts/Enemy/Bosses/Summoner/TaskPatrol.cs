using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter < _waitTime)
            _waiting = false;
        }

        Transform wp = _waypoints[_currentWaypointIndex];
        if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
        {
            //if current position = current set waypoint get next waypoint
            _transform.position = wp.position;
            _waitCounter = 0f;
            _waiting = true;

            //The next waypoint is the next one in the index
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
        else
        {
            //Move the summoner towards the next waypoint at speed x delta time
            _transform.position = Vector2.MoveTowards(_transform.position, wp.position, SummonerBT.speed * Time.deltaTime);
            //_transform.LookAt(wp.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
