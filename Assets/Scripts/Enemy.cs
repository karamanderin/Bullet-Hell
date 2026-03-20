using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    private Transform player;
    public float speed = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public void OnSpawn()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public void OnDespawn() {}

    void Update()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            PoolManager.Instance.ReturnObject("Enemy", gameObject);
        }

        if (col.CompareTag("Player"))
        {
            PoolManager.Instance.ReturnObject("Enemy", gameObject);
        }
    }
}