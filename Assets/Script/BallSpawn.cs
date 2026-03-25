using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}