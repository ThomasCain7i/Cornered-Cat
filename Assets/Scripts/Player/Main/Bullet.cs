using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage;

    public GameObject bullet;
    public float thrust = 1f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody2D>();
    }

    //Apply a force to this Rigidbody in direction of this GameObjects up axis
    void Update()
    {
        rb.AddForce(transform.up * thrust / 10, ForceMode2D.Impulse);
    }

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