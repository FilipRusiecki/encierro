using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public Rigidbody2D rb;
   
    public float speed;
    


    void Start()
    {
       
       
    }
    public void varInit(float t_speed,Rigidbody2D t_rb)
    {
        rb = t_rb;
        speed= t_speed;
    }

    
    void Update()
    {
        transform.position +=Vector3.right *speed*Time.deltaTime;
        if(transform.position.x>8.21)
        {
            Vector3 resetpos = new Vector3 ( -7f, transform.position.y, transform.position.z );
            transform.position = resetpos;
        }
        if (transform.position.x < -8.21)
        {
            Vector3 resetpos = new Vector3(7f, transform.position.y, transform.position.z);
            transform.position = resetpos;
        }
    }
}
