using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleExposed : State
{
    public PlayerController controller;
    public EnemyRangedMovement enemyRangedMovement;
    public float scaredCooldown = 10f;
    public BeetleFinal beetleFinal;

    public override State RunCurrentState()
    {
        scaredCooldown -= Time.deltaTime;
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        if (scaredCooldown > 0)
        {
            controller.currentHealth += 2;
            enemyRangedMovement.speed = 0f;
            enemyRangedMovement.startTimeBetweenShots = 100;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
            return this;
        }
        else
        {
            return beetleFinal;
        }
    }
}