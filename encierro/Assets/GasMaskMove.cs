using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.position -= new Vector3(scrollSpeed, 0.00f, 0.00f);
    }
}
