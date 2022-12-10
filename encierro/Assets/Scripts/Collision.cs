using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChasingEnemy"))
        {
            Destroy(this.gameObject);
            OnPlayerDeath?.Invoke();
            Debug.Log("collided with chasing Enemy");
        }
    }
}
