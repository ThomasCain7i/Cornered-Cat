using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpiderWeb : MonoBehaviour
{
    public PlayerController playerController;
    public EnemyRangedMovement webController;
    public int damage;

    public void Start()
    {
        //Find object that has 
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.TakeDamage(damage);
            playerController.webCooldown += 5f;
        }
    }
}