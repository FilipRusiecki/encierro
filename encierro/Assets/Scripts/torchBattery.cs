using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchBattery : MonoBehaviour
{
    public int initialBatteryPercent = 400;
    public int timePassed = 0;
    public GameObject torchLight;


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
            StartCoroutine(flicker());
            torchLight.SetActive(false);
        }

        if(timePassed < initialBatteryPercent)
        {
            torchLight.SetActive(true);
        }
    }

    public void resetTimePassed()
    {
        timePassed = 0;
    }

    private IEnumerator flicker()
    {
        torchLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        torchLight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        torchLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        torchLight.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        torchLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        torchLight.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        torchLight.SetActive(false);
    }
}
