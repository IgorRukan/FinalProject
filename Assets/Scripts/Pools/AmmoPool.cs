using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    public int amountToPool = 10;
    public Bullet prefab;

    private List<Bullet> pooledObjects;

    private void Awake()
    {
        pooledObjects = new List<Bullet>();
        for (int i = 0; i < amountToPool; i++)
        {
            var go = Instantiate(prefab, transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.gameObject.SetActive(false);
            pooledObjects.Add(go);
        }
    }

    public Bullet GetPooledObjects()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}

