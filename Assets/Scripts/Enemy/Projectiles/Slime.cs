using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Slime : MonoBehaviour
{
    public float timeToDestroy = 5f;
    public Transform Slug;
    public Vector2 target;
    public float speed;

    public void Start()
    {
        Slug = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector2(Slug.position.x, Slug.position.y);
    }
    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {

        }
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}