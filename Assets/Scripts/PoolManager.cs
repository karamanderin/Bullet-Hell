using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public GameObject bulletPrefab;
    public GameObject enemyPrefab;

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreatePool("Bullet", bulletPrefab, 50);
        CreatePool("Enemy", enemyPrefab, 20);
    }

    public void CreatePool(string key, GameObject prefab, int size)
    {
        Queue<GameObject> pool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }

        poolDictionary.Add(key, pool);
    }

    public GameObject GetObject(string key, Vector3 position, Quaternion rotation)
    {
        // 🔥 EĞER POOL BOŞSA YENİ OLUŞTUR
        if (poolDictionary[key].Count == 0)
        {
            GameObject prefab = key == "Bullet" ? bulletPrefab : enemyPrefab;
            GameObject newObj = Instantiate(prefab);
            newObj.transform.position = position;
            newObj.transform.rotation = rotation;
            return newObj;
        }

        GameObject obj = poolDictionary[key].Dequeue();

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    public void ReturnObject(string key, GameObject obj)
    {
        obj.SetActive(false);
        poolDictionary[key].Enqueue(obj);
    }
}