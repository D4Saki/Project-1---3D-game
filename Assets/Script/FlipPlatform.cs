using UnityEngine;

public class FlipPlatform : MonoBehaviour
{
    public float flipInterval = 2f;   // ทุกกี่วินาที
    public float flipSpeed = 200f;    // ความเร็วหมุน

    private bool isFlipping = false;
    private bool flipped = false;

    void Start()
    {
        InvokeRepeating(nameof(StartFlip), flipInterval, flipInterval);
    }

    void StartFlip()
    {
        isFlipping = true;
        flipped = !flipped; // สลับด้าน
    }

    void Update()
    {
        if (isFlipping)
        {
            float targetAngle = flipped ? 180f : 0f;

            float currentZ = transform.eulerAngles.z;
            float newZ = Mathf.MoveTowardsAngle(currentZ, targetAngle, flipSpeed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, 0, newZ);

            // หยุดเมื่อถึงมุม
            if (Mathf.Abs(newZ - targetAngle) < 1f)
            {
                isFlipping = false;
            }
        }
    }
}