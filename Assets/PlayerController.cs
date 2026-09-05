using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if(Input.GetKey(KeyCode.W))
            player.AddForce(Vector3.forward);
        if(Input.GetKey(KeyCode.A))
            player.AddForce(Vector3.back);
         if(Input.GetKey(KeyCode.S))
            player.AddForce(Vector3.left);
         if(Input.GetKey(KeyCode.D))
            player.AddForce(Vector3.right);
    }
}
