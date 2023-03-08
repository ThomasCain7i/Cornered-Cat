/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class TaskSummon : Node
{
    [System.Serializable]
    public class Summon
    {
        private Transform transform;
        public string Name;
        private Transform[] enemies;
        public int count;
        public float rate;
        private float readyTime = 1f;
        public bool ready = false;
        public float readyCounter
        public float timeBetweenSummon;

        public override NodeState Evaluate()
        {
            if (ready)
            {
                readyCounter += Time.deltaTime;
                if (readyCounter < readyTime)
                    ready = true;
            }

            if(transform )
        }
    }
}
*/