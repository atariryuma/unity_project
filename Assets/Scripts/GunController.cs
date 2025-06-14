using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootForce = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (firePoint == null) return;

        GameObject bullet;
        if (bulletPrefab != null)
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.name = "Bullet";
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.transform.localScale = Vector3.one * 0.1f;
            bullet.AddComponent<Rigidbody>();
            bullet.AddComponent<Bullet>();
        }

        var rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * shootForce);
        }
    }
}
