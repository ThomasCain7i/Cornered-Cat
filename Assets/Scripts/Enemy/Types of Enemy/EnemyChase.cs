using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create bit in menu to select scriptable objects
[CreateAssetMenu(menuName = "Enemy/Chase")]
public class EnemyChase : EnemyData
{
    public string targetTag;

    //Override (Do this instead)
    public override void Think(EnemyAI ai)
    {
        //Find the player using tags
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);
        if(target)
        {
            //How to move
            var movement = ai.gameObject.GetComponent<EnemyMovement>();
            if(movement)
            {
                //Where to move
                movement.MoveTowardsTarget(target.transform.position);
            }
        }
    }
}