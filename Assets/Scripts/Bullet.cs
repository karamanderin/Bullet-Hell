using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, IPoolable
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private Coroutine lifeRoutine;

    public void OnSpawn()
    {
       
        if (lifeRoutine != null)
        {
            StopCoroutine(lifeRoutine);
        }

       
        lifeRoutine = StartCoroutine(LifeTimeRoutine());
    }

    public void OnDespawn()
    {
        if (lifeRoutine != null)
        {
            StopCoroutine(lifeRoutine);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    IEnumerator LifeTimeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);

        PoolManager.Instance.ReturnObject("Bullet", gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            PoolManager.Instance.ReturnObject("Bullet", gameObject);
        }
    }
}