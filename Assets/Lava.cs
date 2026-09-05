using UnityEngine;

public class Lava : MonoBehaviour
{
    public float riseSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameManagers>().PlayerDied();
        }
    }
}