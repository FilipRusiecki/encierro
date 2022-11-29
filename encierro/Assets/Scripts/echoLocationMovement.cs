using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoLocationMovement : MonoBehaviour
{
    private float speed = 0.9f;
    public GameObject bat;
    public bool hitPlayer;


    private void Start()
    {
        hitPlayer = false;
    }
  
    private void FixedUpdate()
    {
        transform.position += Vector3.left * (speed+1.2f) * Time.deltaTime;
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = new Vector3(bat.transform.position.x,bat.transform.position.y,bat.transform.position.z);
          
        }
        if (collision.gameObject.tag == "Player")
        {
            hitPlayer = true;
            transform.position = new Vector3(bat.transform.position.x, bat.transform.position.y, bat.transform.position.z);
           
          
        }
    }
}
