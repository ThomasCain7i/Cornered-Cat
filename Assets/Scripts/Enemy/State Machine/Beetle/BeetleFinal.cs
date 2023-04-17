using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleFinal : State
{
    public override State RunCurrentState()
    {
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        return this;
    }
}