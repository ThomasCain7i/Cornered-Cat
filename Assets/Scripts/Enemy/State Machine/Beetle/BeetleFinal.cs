using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleFinal : State
{
    public PlayerController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public override State RunCurrentState()
    {
        controller.currentHealth = controller.maxHealth;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        return this;
    }
}