using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyData : ScriptableObject
{
    public abstract void Think(EnemyAI ai);
}
