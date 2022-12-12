using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
        Rigidbody2D _rb;
        public float _speed = 0f;
        public float _bounds;

    private void Start()
    {
        transform.localScale = new Vector3(Random.Range(0.4f, 0.75f), Random.Range(0.75f, 2.0f), 1f);
        float offsetY = transform.localScale.y / 2.0f;
        transform.position = new Vector3(Random.Range(10.0f, 16.0f), -4.0f + offsetY, 1f);
    }
    private void Update()
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
            if (transform.position.x < _bounds)
            {
                Destroy(this.gameObject);
            }
        }
    public void SetSpeed(float t_speed)
    {
        _speed = t_speed;
    }
    
}
