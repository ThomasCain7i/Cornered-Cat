using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        //Find player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Targte = where player is now.
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        //transform.position = move towards target
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if bullet is at target, destory it
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    //When colliding with trigger on enter, destroy
    void OnTriggerCollide2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision with projectile");
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}