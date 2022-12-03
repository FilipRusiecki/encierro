using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchBattery : MonoBehaviour
{
    public int initialBatteryPercent = 1000;
    public int timePassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timePassed++;

        if(timePassed == initialBatteryPercent)
        {
            // turn off the torch
        }
    }
}
