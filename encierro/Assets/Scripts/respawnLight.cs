using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnLight : MonoBehaviour
{
    public GameObject myLightFixture;

    // Start is called before the first frame update
    void Start()
    {
        //myLightFixture = GameObject.FindWithTag("lightFixture");

    }

    // Update is called once per frame
    void Update()
    {
        if(myLightFixture.transform.position.x <= -12.5)
        {
            myLightFixture.transform.position = new Vector3(13.5f, myLightFixture.transform.position.y, myLightFixture.transform.position.z);
        }
    }
}
