using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasFieldMove : MonoBehaviour
{
    public float scrollSpeed;
    public float _bounds;

    void Start()
    {
    }
    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x < _bounds)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetSpeed(float t_speed)
    {
        scrollSpeed = t_speed;
    }
}

