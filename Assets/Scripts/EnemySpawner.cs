using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
    }

    void SpawnEnemy()
    {
        Vector2 pos = Random.insideUnitCircle * 5f;

        PoolManager.Instance.GetObject(
            "Enemy",
            pos,
            Quaternion.identity
        );
    }
}