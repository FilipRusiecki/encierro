using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatMovement : MonoBehaviour
{

    public int speed;
    public int bounds;

    private float startPosX = 3.0f;
    private float startPosY = 4.0f;

    private float degrees=45.0f; 
    private float posXOffset = 8;
    public GameObject echo;

    private float RotateSpeed = 1.5f;
    private float Radius = 5.0f;

    private Vector2 centre;
   
    private float timer;
    bool hitPlayerMaybe = false;

    private void Start()
    {
        transform.position = new Vector3(startPosX, startPosY, transform.position.z);
        centre = transform.position;
        //isSWeeping = false;
        timer = 0;
      
    }
    void swoopingMovement()
    {
        Debug.Log(transform.position + gameObject.name);
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
            resetPos();
        }
    }

    public void stateChecker(bool t_b)
    {
        hitPlayerMaybe = t_b;
        //if (hitPlayerMaybe == true)
        //{
        //    swoopingMovement();
        //}
    }

    private void FixedUpdate()
    {
        if (hitPlayerMaybe == false)
        {
            searching();
        }
        else
        {
            swoopingMovement();
        }
    }

    void searching()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            createEcho();
            timer = 0;
        }
    }

    private void createEcho()
    {
        GameObject temp = Instantiate(echo, transform.position, Quaternion.identity);
        Destroy(temp, 5.0f);
    }


    public void resetPos()
    {
        transform.position = new Vector3(startPosX, startPosY, transform.position.z);
    }
}
