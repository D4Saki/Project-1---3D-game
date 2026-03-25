using UnityEngine;

public class Trap : MonoBehaviour
{
    public Transform spawnPoint;
    public float respawnDelay = 1f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(RespawnWithDelay(col.gameObject));
        }
    }

    System.Collections.IEnumerator RespawnWithDelay(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();

        // หยุดการเคลื่อนที่
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // ปิดการควบคุม (optional)
        player.SetActive(false);

        // ⏳ รอเวลา
        yield return new WaitForSeconds(respawnDelay);

        // เปิดกลับ
        player.SetActive(true);

        // ย้ายกลับจุดเกิด
        player.transform.position = spawnPoint.position;
    }
}