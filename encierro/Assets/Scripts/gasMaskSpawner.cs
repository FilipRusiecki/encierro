using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasMaskSpawner : MonoBehaviour
{

    public GameObject gasMask;

    public int amountOfGasMaskToSpawn;
    public int amountOfGasMaskToSpawned;
    public float timeBetweenSpawns;
    public bool spawnNow = true;

    public bool alive = true;
    public float randomPickSpawn;


    //new events
    public List<GameObject> gameEvents;

    public float timer = 0;
    private bool timerBool = true;

    public int randomEventCall;

    [Header("Positions Off Screen")]
    public List<Transform> Transforms;



    private void FixedUpdate()
    {
        randomEventCall = Random.Range(0, 3);
        if (timerBool == true)
        {
            timerBool = false;
            StartCoroutine(timerCounter());
            checkEvents();
        }
        //random transform
        randomPickSpawn = Random.Range(0, 2);
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
        if (timer == 5)
        {
            if (randomEventCall == 0)
            {
                Debug.Log("event 1");
                if (amountOfGasMaskToSpawn > amountOfGasMaskToSpawned && spawnNow == true)
                {
                    spawnNow = false;
                    StartCoroutine(spawnMasks());
                    StartCoroutine(spawnGasField());

                }
            }

            if (randomEventCall == 1)
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
            if (randomEventCall == 0)
            {
                Debug.Log("event 1");
                if (amountOfGasMaskToSpawn > amountOfGasMaskToSpawned && spawnNow == true)
                {
                    spawnNow = false;
                    StartCoroutine(spawnMasks());
                    StartCoroutine(spawnGasField());

                }
            }

            if (randomEventCall == 1)
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
        if (timer == 15)
        {
            if (randomEventCall == 0)
            {
                Debug.Log("event 1");
                if (amountOfGasMaskToSpawn > amountOfGasMaskToSpawned && spawnNow == true)
                {
                    spawnNow = false;
                    StartCoroutine(spawnMasks());
                    StartCoroutine(spawnGasField());

                }
            }

            if (randomEventCall == 1)
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






    IEnumerator spawnMasks()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        if (randomPickSpawn == 0)
        {
            Instantiate(gasMask, Transforms[0].transform.position, Transforms[0].transform.rotation);
        }
        else if (randomPickSpawn == 1)
        {
            Instantiate(gasMask, Transforms[1].transform.position, Transforms[1].transform.rotation);
        }
        amountOfGasMaskToSpawned++;
        spawnNow = true;
    }




    IEnumerator spawnGasField()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        Instantiate(gameEvents[0], Transforms[2].transform.position, Transforms[2].transform.rotation);
        

    }
}
