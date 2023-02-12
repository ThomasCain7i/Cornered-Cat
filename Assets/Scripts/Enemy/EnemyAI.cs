using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyData enemyData;
    public PlayerController playerController;
    public int damage;

    // Update is called once per frame
    private void Update()
    {
        enemyData.Think(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController.TakeDamage(damage);
        }
    }
}