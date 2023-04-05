using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeetleSM : MonoBehaviour
{
    //Attack
    public float attackCooldown;
    public float maxAttackCooldown = 5;
    public GameObject projectile;
    public EnemyHealth beetleHealth;

    //Ultimate Attack
    public float ultimateCooldown;
    public float maxUltimateAttackCooldown = 1;

    public enum AIState { chasing, attack, ultra };

    public AIState aiState = AIState.chasing;

    void Start()
    {
        attackCooldown = maxAttackCooldown;
        beetleHealth = GameObject.Find("Beetle").GetComponent<EnemyHealth>();
        StartCoroutine(Beetle());
    }

    IEnumerator Beetle()
    {
        while (true)
        {
            switch (aiState)
            {
                case AIState.chasing:
                    attackCooldown -= Time.deltaTime;
                    if (attackCooldown > 0)
                    {

                    }
                    else
                    {
                        aiState = AIState.attack;
                    }
                    if(beetleHealth.currentHealth == 10)
                    {
                        aiState = AIState.ultra;
                    }
                    break;

                case AIState.attack:
                    if(attackCooldown <= 0)
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    attackCooldown = maxAttackCooldown;
                    if(attackCooldown > 0)
                    {
                        aiState -= AIState.chasing;
                    }
                    else
                    {
                        attackCooldown -= Time.deltaTime;
                    }
                    if (beetleHealth.currentHealth == 10)
                    {
                        aiState = AIState.ultra;
                    }
                    break;

                case AIState.ultra:
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    ultimateCooldown = maxUltimateAttackCooldown;
                    break;
            }
        }
    }
}
