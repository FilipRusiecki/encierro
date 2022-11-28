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

    public Transform gasMaskSpawnPos;
    public Transform gasMaskSpawnPos2;
    public float randomPickSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        randomPickSpawn = Random.Range(0,2);
        if(amountOfGasMaskToSpawn == amountOfGasMaskToSpawned)
        {
            spawnNow = false;   
        }
        if (amountOfGasMaskToSpawn > amountOfGasMaskToSpawned && spawnNow == true)
        {
            spawnNow = false;
            StartCoroutine(spawnMasks());
        }
      
    }



    IEnumerator spawnMasks()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        if (randomPickSpawn == 0)
        {
            Instantiate(gasMask, gasMaskSpawnPos.transform.position, gasMaskSpawnPos.transform.rotation);
        }
        else if (randomPickSpawn == 1)
        { 
            Instantiate(gasMask, gasMaskSpawnPos2.transform.position, gasMaskSpawnPos2.transform.rotation);
        }
        amountOfGasMaskToSpawned++;
        spawnNow = true;
    }
}
