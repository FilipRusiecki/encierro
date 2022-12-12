using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMaskPickup : MonoBehaviour
{
    [Header("GasMask")]
    public player player;
    public Image gasBar;
    public GameObject bar;
    public bool gasMaskPickedUp = false;
    public GameObject playerGasMask;
    public bool inGas = false;

    //public bool torchPickedUp = false;
    // public GameObject torchObject;
    private void Start()
    {
       // GasMaskObject = player.transform.Find("PlayerGasMask").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("GasMask"))
        {
            //Debug.Log("pick up gasmask");
            //collision.gameObject.SetActive(false);
            //gasBar.fillAmount = 1.0f;

            //gasBar.gameObject.SetActive(true);
            //bar.SetActive(true);
            //gasMaskPickedUp = true;
       
            //Destroy(collision.gameObject);

        }

        if (collision.CompareTag("GasField"))
        {
            //inGas = true;
        }


        //if (collision.CompareTag("TorchPickup"))
        //{
        //    torchPickedUp = true;
        //}
    }

    public void setInGas()
    {
        if(inGas == false)
        {
            inGas = true;
        }
    }
    public void resetInGas()
    {
        if (inGas == true)
        {
            inGas = false;
        }
    }
    public void setUpGasBar()
    {
       // Debug.Log("Herrrrereeeeeee");
        gasBar.fillAmount = 1.0f;
        gasBar.gameObject.SetActive(true);
        bar.SetActive(true);
        gasMaskPickedUp = true;
    }

    void decrement()
    {
        gasBar.fillAmount -= 0.25f * Time.deltaTime;
    }

    private void Update()
    {
            //if (inGas == true)
            //{
            //    if (gasMaskPickedUp == false)
            //    {
            //        Debug.Log("NoGasMask Equipped");
            //    }
            //}

        if (gasMaskPickedUp == true)
        {
            if (inGas == true)
            {
                decrement();
            //    if (gasBar.fillAmount <= 0.0)
            //    {
            //        Debug.Log("outofGasMask");
            //        gasBar.gameObject.SetActive(false);
            //        bar.SetActive(false);
            //        gasMaskPickedUp = false;
            //        playerGasMask.gameObject.SetActive(false);
            //        GasMaskObject.gameObject.SetActive(false);

            //    }
            }
        }
        if (gasBar.fillAmount <= 0.0)
        {
            gasBar.gameObject.SetActive(false);
            bar.SetActive(false);
            gasMaskPickedUp = false;
            // GasMaskObject.gameObject.SetActive(false);
            playerGasMask.gameObject.SetActive(false);
           // inGas = false;
        }

        //if (torchPickedUp == true)
        //{
        //    torchObject.SetActive(true);
        //}

        //if (torchPickedUp == false)
        //{
        //    torchObject.SetActive(false);
        //}
    }
}
