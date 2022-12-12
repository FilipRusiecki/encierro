using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullBackCentre : MonoBehaviour
{
    private int speed = 2;
    private void Update()
    {
            transform.position += -Vector3.left * speed * Time.deltaTime;
    }
}
