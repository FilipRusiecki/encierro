using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchPickup : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public int bounds;

    public GameObject playersTorch;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < bounds)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed(float t_speed)
    {
        speed = t_speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            playersTorch.transform.Find("Torch").gameObject.SetActive(true);
        }

    }
}
