using UnityEngine;

public class Spin_Barrel : MonoBehaviour
{
    public float spinSpeed = 200f;   // ความเร็วหมุน
    public Vector3 spinAxis = Vector3.forward; // แกนหมุน

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ทำให้หมุนลื่น ๆ
        rb.angularVelocity = spinAxis * spinSpeed * Mathf.Deg2Rad;
    }

    void FixedUpdate()
    {
        // คงความเร็วหมุนไว้ตลอด
        rb.angularVelocity = spinAxis * spinSpeed * Mathf.Deg2Rad;
    }
}