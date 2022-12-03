using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskPickup : MonoBehaviour
{
    public GameObject GasMaskObject;
    public player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("GasMask"))
        {
            Debug.Log("pick up gasmask");
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            GasMaskObject.SetActive(true);
        }

    }


}
