using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //On collision with bullet do:
        switch (other.gameObject.tag)
        {

            // Collision with wall just destroy bullet
            case "Wall":
                Destroy(gameObject);
                break;
            // Collision with enemy deal 1 damage and destory
            case "Enemy":
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                Destroy(gameObject);
                break;
            case "EnemySplit":
                other.gameObject.GetComponent<EnemySplit>().TakeDamage(1);
                Destroy(gameObject);
                break;
        }
    }
}
