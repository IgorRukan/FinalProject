using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    private int amountToPool;
    public Spawn prefab;

    private List<Spawn> pooledObjects;
    public List<DamageableObject> objects;

    private void Awake()
    {
        pooledObjects = new List<Spawn>();

        amountToPool = objects.Count;
        
        for (int i = 0; i < amountToPool; i++)
        {
            var go = Instantiate(prefab, transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            pooledObjects.Add(go);
            go.spawnObject = objects[i];
        }
    }

    public Spawn GetPooledObjects()
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
