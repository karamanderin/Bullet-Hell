using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.2f; // ateş aralığı

    private float nextFireTime = 0f;

    public void Shoot()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        PoolManager.Instance.GetObject(
            "Bullet",
            firePoint.position,
            firePoint.rotation
        );
    }
}