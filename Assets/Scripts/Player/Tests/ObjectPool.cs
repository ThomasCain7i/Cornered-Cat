using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private int amountToPool = 8;

    public Transform firePoint;
    public float fireForce;

    [SerializeField] private GameObject prefab;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for( int i = 0; i < amountToPool; i++)
        {
            GameObject Object = Instantiate(prefab, firePoint.position, firePoint.rotation);
            Object.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            Object.SetActive(false);
            pooledObjects.Add(Object);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}