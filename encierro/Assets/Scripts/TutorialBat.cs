using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBat : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int bounds;

    private float startPosX;
    private float startPosY = 0.5f;

    private float degrees = 45.0f;
    private float posXOffset = 8;
    public GameObject echo;
    public direction enumCounter;
    private float RotateSpeed = 1.5f;
    private float Radius = 5.0f;

    private Vector2 centre;

    private float timer;
    bool hitPlayerMaybe = false;


    private void Start()
    {
        startPosX = 4;
        transform.position = new Vector3(startPosX, startPosY, transform.position.z);
        centre = transform.position;
        timer = 0;
    }
    void swoopingMovement()
    {

        transform.position += Vector3.left * speed * Time.deltaTime;


        if (transform.position.y > -3.0 && transform.position.y < 8)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            degrees += RotateSpeed * Time.deltaTime;
            var offset = new Vector2(Mathf.Sin(degrees), Mathf.Cos(degrees)) * Radius;
            transform.position = centre + offset;
        }

        // added spawn control this position can change or the condition will change once the radar or echo locationis done 
        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
    }
       

    public void stateChecker(bool t_b)
    {
        hitPlayerMaybe = t_b;

    }

    private void Update()
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

        if (enumCounter == direction.left)
        {
            temp.gameObject.GetComponent<TutorialEcho>().xAxisSpeed *= -1;
        }
        Destroy(temp, 5.0f);
    }



}
