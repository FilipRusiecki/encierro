using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
    public GameObject object2;// the second object
    public GameObject object1;// the first object

    public Collider2D object2Collider;
    public Collider2D object1Collider;

    public bool isCOlliding = false;


    public void VarInitFunc(GameObject g_1,GameObject g_2)
    {
        object1 = g_1!;
        object2 = g_2;
        object2Collider = object2.GetComponent<Collider2D>();
        object1Collider = object1.GetComponent<Collider2D>();
    }
  
    // Update is called once per frame
    void Update()
    {
        isCOlliding = AABBFunc();
    }

    public bool AABBFunc()
    {
        if (object1.transform.position.x < object2.transform.position.x + object2Collider.bounds.size.x &&
            // checks to see if object 1 + width is greater than the object 2. postition . x
            object1.transform.position.x + object1Collider.bounds.size.x > object2.transform.position.x &&
            // checks to see if object 1 .y is less than object 2 .position.y + height of object 2
            object1.transform.position.y < object2.transform.position.y + object2Collider.bounds.size.y &&
            // checks to see if object 1 position.y is greater than object 2. position + object 2 height
            object1.transform.position.y + object1Collider.bounds.size.y > object2.transform.position.y)
        {
            Debug.Log(" box to box collision");
            return true;
        }
        return false;
    }

    }
