using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDark : MonoBehaviour
{
    public int goDarkNum = 0;

    bool dark = false;

    private GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("lightFixture");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goDarkNum++;

        if (goDarkNum >= 500)
        {
            goDarkNum = 0;
            if (dark == false)
            {
                dark = true;
            }
            else if (dark == true)
            {
                dark = false;
            }
        }

        if (dark == true)
        {
            for(int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false);
            }
        }

        if (dark == false)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(true);
            }
        }
    }

}
