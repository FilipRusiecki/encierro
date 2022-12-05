using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public BoxCollider2D collider;
    [SerializeField]
    public float speed =0f;
    float width = 18f;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -width)
        {
            SetPosition(width);
        }
    }

    public void SetSpeed(float t_speed)
    {
        speed = t_speed;
    }
    public void SetPosition(float t_position)
    {
        transform.position = new Vector3(t_position, transform.position.y, 0f); 
    }
}
