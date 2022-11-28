using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{

    public int speed;
    public int bounds;
  
    private float startPosY = 4.0f;
    private float startPosX = 5.0f;

    private float degrees=45.0f; 
    private float posXOffset = 8;
   

    private float RotateSpeed = 1.5f;
    private float Radius = 3.0f;

    private Vector2 centre;
    

    private void Start()
    {
        centre = transform.position;
      
      
    }

    private void FixedUpdate()
    {

           transform.position += Vector3.left * speed * Time.deltaTime;
         
       
        if (transform.position.y > 1 && transform.position.y < 8)
        {
                transform.position += Vector3.down * speed * Time.deltaTime;
                degrees += RotateSpeed * Time.deltaTime;
                var offset = new Vector2(Mathf.Sin(degrees), Mathf.Cos(degrees)) * Radius;
                transform.position = centre + offset;
        }
     
        // added spawn control this position can change or the condition will change once the radar or echo locationis done 
        if (transform.position.x < bounds - posXOffset)
        {
            degrees = 45.0f;
            transform.position = new Vector3(startPosX, startPosY, transform.position.z);
        }
    }
}
