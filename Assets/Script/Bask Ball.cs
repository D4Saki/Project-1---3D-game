using UnityEngine;

public class BaskBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;

    public float forceMultiplier = 15f;
    public float mass = 1f;

    private bool canShoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;

        // สร้างลูกใหม่
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = newBall.GetComponent<Rigidbody>();

        // เล็ง
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(10f);

        Vector3 direction = (targetPoint - spawnPoint.position).normalized;

        // F = ma
        Vector3 force = mass * forceMultiplier * direction;

        rb.AddForce(force, ForceMode.Impulse);

        // spawn ลูกใหม่หลัง 2 วิ
        Invoke(nameof(ResetShoot), 2f);
    }

    void ResetShoot()
    {
        canShoot = true;
    }
}