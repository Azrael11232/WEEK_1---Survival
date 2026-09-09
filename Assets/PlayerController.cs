using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform;

    public float speed = 6f;
    public float jumpForce = 7f;
    public float blinkDistance = 5f;

    bool isGrounded = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Blink();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

       
        Vector3 movement = forward * z + right * x;
        movement.Normalize();

        rb.MovePosition(
            rb.position + movement * speed * Time.fixedDeltaTime
        );

        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void Blink()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 destination = rb.position + forward * blinkDistance;


        Vector3 rayStart = destination + Vector3.up * 10f;

        RaycastHit hit;


        if (Physics.Raycast(rayStart, Vector3.down, out hit, 20f))
        {
            destination = hit.point;  

            destination.y += 0.5f;

            if (destination.y < 0f)
            {
                destination.y = 0f;
            }

            rb.MovePosition(destination);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}