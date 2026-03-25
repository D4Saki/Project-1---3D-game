using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float delay = 1f;
    private Rigidbody rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            Invoke("Fall", delay);
        }
    }

    void Fall()
    {
        rb.isKinematic = false;
    }
}