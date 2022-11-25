using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public int bounds;

    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x<bounds)
        {
            transform.position = new Vector3(8,transform.position.y,transform.position.z);
        }
    }
   
}
