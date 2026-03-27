using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    public Rigidbody rb;
    public Transform cameraTransform;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // เอาทิศจากกล้อง
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ไม่เอาแกน Y (กันลอย)
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // ทิศเดินตามกล้อง
        Vector3 move = forward * v + right * h;

        // คุมความเร็ว
        Vector3 velocity = rb.velocity;
        velocity.x = move.x * speed;
        velocity.z = move.z * speed;
        rb.velocity = velocity;

        // หมุนตัวตามทิศเดิน
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}