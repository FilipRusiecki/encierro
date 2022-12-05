using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayToCircleBox : MonoBehaviour
{



    public LayerMask selfCollisionLayer;
    public float rayCastLength;
    public bool hitLeft;
    public bool hitRight;
    public bool hitUp;
    public bool hitDown;
    public Rigidbody2D rb2D;
    RaycastHit2D hit;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(hitDown==true)
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastLength, ~selfCollisionLayer);
            Debug.DrawRay(transform.position, Vector2.down * rayCastLength, Color.red);
        }
        if (hitLeft == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, rayCastLength, ~selfCollisionLayer);
            Debug.DrawRay(transform.position, Vector2.left * rayCastLength, Color.red);
        }
        if (hitUp == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, rayCastLength, ~selfCollisionLayer);
            Debug.DrawRay(transform.position, Vector2.up * rayCastLength, Color.red);
        }
        if (hitRight == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayCastLength, ~selfCollisionLayer);
            Debug.DrawRay(transform.position, Vector2.right * rayCastLength, Color.red);
        }
       

        // if the object hists anything to the left it will move to the right
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
           // Debug.Log("hit an object to the left ");
        }
    }
}
