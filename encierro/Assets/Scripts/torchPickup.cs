using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchPickup : MonoBehaviour
{

    Rigidbody2D rb;
    public int speed;
    public int bounds;

    public GameObject playersTorch;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < bounds)
        {
            transform.position = new Vector3(13, transform.position.y, transform.position.z);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            playersTorch.transform.Find("Torch").gameObject.SetActive(true);
        }

    }
}
