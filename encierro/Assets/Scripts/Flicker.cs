using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public GameObject myLight;


    // Start is called before the first frame update
    void Start()
    {
        myLight = GameObject.FindWithTag("light");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {          
           StartCoroutine(flicker());
        }
    }

    private IEnumerator flicker()
    {
        myLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        myLight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        myLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        myLight.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        myLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        myLight.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        myLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        myLight.SetActive(true);
    }


}
