using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public PlayerController controller;
    public EnemyHealth enemyHealth;
    public GameObject prefab;

    public float timeBetweenSummon = 5;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenSummon -= Time.deltaTime;

        if (timeBetweenSummon < 0)
        {
            Instantiate(prefab, spawnPoint1);
            Instantiate(prefab, spawnPoint2);
            Instantiate(prefab, spawnPoint3);
            Instantiate(prefab, spawnPoint4);
            timeBetweenSummon = 5;
        }

        if(enemyHealth.currentHealth == 1)
        {
            controller.currentHealth = controller.maxHealth;
        }
    }
}
