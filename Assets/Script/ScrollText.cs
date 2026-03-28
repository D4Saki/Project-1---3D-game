using UnityEngine;
using UnityEngine.UI;
public class ScrollText : MonoBehaviour
{
    public float scrollSpeed = 40f; // ความเร็วในการเลื่อนข้อความ
    private RectTransform RectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime; // เลื่อนข้อความขึ้น
    }
}
