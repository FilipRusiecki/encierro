using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnPlayerDeath?.Invoke();
            Debug.Log("collidede with Enemy");
        }
    }
}
