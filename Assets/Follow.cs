using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public Transform Camera;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.position = player.transform.position + offset;
    }
}
