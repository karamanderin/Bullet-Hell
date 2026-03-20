using UnityEngine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    WeaponSystem weapon;

    void Start()
    {
        cam = Camera.main;
        weapon = GetComponent<WeaponSystem>();
    }

    void Update()
    {
        Rotate();

        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
    }

    void Rotate()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouse - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}