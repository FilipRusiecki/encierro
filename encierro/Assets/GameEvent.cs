using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    private float timer = 0;
    private bool timerBool = true;

    private int randomEventCall;
    [Header("Events")]
    public List<GameObject> GameObjectsOfEvents;
    [Header("Positions Off Screen")]
    public List<Transform> Transforms;


    private void Update()
    {
        randomEventCall = Random.Range(0, GameObjectsOfEvents.Capacity);
        if (timerBool == true)
        {
            timerBool = false;
            StartCoroutine(timerCounter());
        }
        checkEvents();
    }


    IEnumerator timerCounter()
    {
        yield return new WaitForSeconds(1.0f);
        timer++;
        timerBool = true;
    }


    public void checkEvents()
    {
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
        //first event
        if (timer == 10)
        {
            if (randomEventCall == 1)
            {
                Debug.Log("event 1");
            }

            if (randomEventCall == 2)
            {
                Debug.Log("event 2");
            }

            if (randomEventCall == 2)
            {
                Debug.Log("event 3");
            }
        }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
        //second event
        if (timer == 10)
        {
            if (randomEventCall == 1)
            {
                Debug.Log("event 1");
            }

            if (randomEventCall == 2)
            {
                Debug.Log("event 2");
            }

            if (randomEventCall == 2)
            {
                Debug.Log("event 3");
            }
        }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
        //third event
        if (timer == 14)
        {
            if (randomEventCall == 1)
            {
                Debug.Log("event 1");
            }

            if (randomEventCall == 2)
            {
                Debug.Log("event 2");
            }

            if (randomEventCall == 2)
            {
                Debug.Log("event 3");
            }
        }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
