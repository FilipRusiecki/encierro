using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerTwo : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody2D rb;
    public float jumpForce = 5;
    public float jumpCount = 0;
    public int jumpsAllowed = 100;
    bool isGrounded = true;
    int speed = 2;


    public VisualEffect vfxRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //These calls will grab the RigidBody and the Particle system that is attached as a child object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Really basic movement used down below 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount += 1;
       
            if (jumpCount == jumpsAllowed)
            {
                isGrounded = false;
            }

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
           

        }

        vfxRenderer.SetVector3("ColliderPos", transform.position);



    }
}
