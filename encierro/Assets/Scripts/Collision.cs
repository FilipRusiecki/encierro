using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject playersGasMask;
    public static event Action OnPlayerDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChasingEnemy"))
        {
            Destroy(this.gameObject);
            OnPlayerDeath?.Invoke();
            Debug.Log("collided with chasing Enemy");
        }
        if (collision.gameObject.tag.Equals("GasField"))
        {
            Debug.Log("Entered gas Field");
            playersGasMask.GetComponent<GasMaskPickup>().setInGas();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GasField"))
        {
            playersGasMask.GetComponent<GasMaskPickup>().resetInGas();
            Debug.Log("Exited gas Field");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("GasField"))
        {
            Debug.Log("Still in Field");
            if (playersGasMask.GetComponent<GasMaskPickup>().gasMaskPickedUp == false)
            {
                Destroy(this.gameObject);
                OnPlayerDeath?.Invoke();
            }
        }
    }

}
