using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float distance = 6f;
    public float height = 3f;
    public float sensitivity = 3f;

    float rotationX = 20f;
    float rotationY = 0f;

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, 5f, 60f);
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        transform.position = player.position - transform.forward * distance + Vector3.up * height;
    }
}
