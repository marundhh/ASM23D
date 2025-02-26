using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;    // Vị trí bắn
    public GameObject bulletPrefab;       // Prefab đạn
    public float bulletSpeed = 50f;       // Tốc độ đạn
    public Camera playerCamera;           // Camera của người chơi
    public float shotDelay = 1f;          // Thời gian chờ sau khi nhấn chuột

    private bool isShooting = false;      // Tránh spam bắn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isShooting)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        isShooting = true;                      // Đánh dấu đang bắn
        yield return new WaitForSeconds(shotDelay); // Chờ 1 giây

        Shoot();                                // Thực hiện bắn
        isShooting = false;                     // Cho phép bắn tiếp
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 shootDirection = playerCamera.transform.forward; // Hướng theo camera
            rb.velocity = shootDirection * bulletSpeed;
        }
    }
}
