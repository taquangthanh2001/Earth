using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private Dictionary<GameObject, Queue<GameObject>> poolDictionary =
        new Dictionary<GameObject, Queue<GameObject>>();

    private Dictionary<GameObject, GameObject> spawnedToPrefab =
        new Dictionary<GameObject, GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            poolDictionary[prefab] = new Queue<GameObject>();
        }

        Queue<GameObject> poolQueue = poolDictionary[prefab];

        GameObject obj;

        if (poolQueue.Count > 0)
        {
            obj = poolQueue.Dequeue();
        }
        else
        {
            obj = Instantiate(prefab);
            spawnedToPrefab[obj] = prefab;
        }

        obj.transform.SetPositionAndRotation(position, rotation);
        obj.SetActive(true);

        return obj;
    }

    public void Despawn(GameObject obj)
    {
        if (!spawnedToPrefab.ContainsKey(obj))
        {
            Destroy(obj);
            return;
        }

        GameObject prefab = spawnedToPrefab[obj];

        obj.SetActive(false);
        poolDictionary[prefab].Enqueue(obj);
    }
}