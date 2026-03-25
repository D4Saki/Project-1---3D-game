using UnityEngine;

public class Wind : MonoBehaviour
{
    public float force = 10f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * force);
        }
    }
}// ยืด Box collider เอ่า
