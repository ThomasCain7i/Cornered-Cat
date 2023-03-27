using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplit : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Instantiate(gameObject);
            Destroy(gameObject);
        }
    }
}
