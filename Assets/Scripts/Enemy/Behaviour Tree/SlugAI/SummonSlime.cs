using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSlime : MonoBehaviour
{
    public GameObject prefab;

    public float timeBetweenSummon = 0.2f;

    public Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        timeBetweenSummon -= Time.deltaTime;

        if (timeBetweenSummon <= 0)
        {
            Instantiate(prefab, spawnPoint);

            timeBetweenSummon = 0.2f;
        }
    }
}
