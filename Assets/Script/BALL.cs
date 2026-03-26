using UnityEngine;

public class BALL : MonoBehaviour
{
    public float swingAngle = 45f;   // แกว่งกี่องศา
    public float speed = 2f;         // ความเร็ว

    private Vector3 startRotation;

    void Start()
    {
        startRotation = transform.eulerAngles;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * swingAngle;

        transform.eulerAngles = new Vector3(
            startRotation.x,
            startRotation.y,
            startRotation.z + angle
        );
    }
}
