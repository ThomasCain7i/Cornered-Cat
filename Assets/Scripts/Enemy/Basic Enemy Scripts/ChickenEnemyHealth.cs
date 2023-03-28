using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEnemyHealth : MonoBehaviour
{
    public PlayerController playerController;
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
            playerController.currentHealth += 1;
            Destroy(gameObject);
        }
    }
}
