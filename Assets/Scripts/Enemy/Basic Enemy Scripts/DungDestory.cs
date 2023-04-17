using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungDestory : MonoBehaviour
{
    public float destroy;
    // Start is called before the first frame update
    void Start()
    {
        destroy = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        destroy -= Time.deltaTime;
        if(destroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
