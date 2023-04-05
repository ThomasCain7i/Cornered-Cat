using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletOP : MonoBehaviour
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
                gameObject.SetActive(false);
                break;
            // Collision with enemy deal 1 damage and destory
            case "Enemy":
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                gameObject.SetActive(false);
                break;
        }
    }
}
