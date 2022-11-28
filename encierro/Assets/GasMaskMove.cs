using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float scrollSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }
    void FixedUpdate()
    {
        rb.transform.position -= new Vector3(scrollSpeed, 0.00f, 0.00f);
    }
}
