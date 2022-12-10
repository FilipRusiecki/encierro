using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMaskPickup : MonoBehaviour
{
    [Header("GasMask")]
    public GameObject GasMaskObject;
    public player player;
    public Image gasBar;
    public GameObject bar;
    public bool gasMaskPickedUp = false;

    public bool inGas = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("GasMask"))
        {
            Debug.Log("pick up gasmask");
            collision.gameObject.SetActive(false);
            gasBar.fillAmount = 1.0f;

            gasBar.gameObject.SetActive(true);
            bar.SetActive(true);
            gasMaskPickedUp = true;
       
            Destroy(collision.gameObject);
            GasMaskObject.SetActive(true);
        }

        if (collision.CompareTag("GasField"))
        {
            inGas = true;
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GasField"))
        {
            inGas = false;
        }
    }

    void decrement()
    {
        gasBar.fillAmount -= 0.1f * Time.deltaTime;
    }

    private void Update()
    {

        if (inGas == true)
        {
            if (gasMaskPickedUp == false)
            {
                Debug.Log("NoGasMask Equipped");
            }
        }

        if (gasMaskPickedUp == true)
        {
            if (inGas == true)
            {
                decrement();
                if (gasBar.fillAmount <= 0.0)
                {
                    Debug.Log("outofGasMask");
                    gasBar.gameObject.SetActive(false);
                    bar.SetActive(false);
                    gasMaskPickedUp = false;
                    GasMaskObject.SetActive(false);

                }
            }
        }
        if (gasBar.fillAmount <= 0.0)
        {
            gasBar.gameObject.SetActive(false);
            bar.SetActive(false);
            gasMaskPickedUp = false;
            GasMaskObject.SetActive(false);
            inGas = false;
        }
    }

}
