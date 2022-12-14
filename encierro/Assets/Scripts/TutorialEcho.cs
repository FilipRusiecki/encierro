using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEcho : MonoBehaviour
{
    public float speed = 0.9f;
    public float xAxisSpeed = 0.9f;
    public GameObject bat;
    public bool hitPlayer;


    private void Start()
    {
        bat = GameObject.FindGameObjectWithTag("Bat");
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * (xAxisSpeed) * Time.deltaTime;
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = new Vector3(bat.transform.position.x, bat.transform.position.y, bat.transform.position.z);

        }
        if (collision.gameObject.tag == "Player")
        {

            bat.GetComponent<TutorialBat>().stateChecker(true);

            //transform.position = new Vector3(bat.transform.position.x, bat.transform.position.y, bat.transform.position.z);
            Destroy(gameObject);
            // added collision for the bat and the player but need to change the state based off of that 

        }
    }
}
