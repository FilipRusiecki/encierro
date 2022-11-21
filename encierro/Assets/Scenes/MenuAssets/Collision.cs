//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Collision : MonoBehaviour
//{
//    public static event Action OnPlayerDeath;
//    public GameObject lizard;

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Enemy"))
//        {
//            Debug.Log("collided with enemy");
//            OnPlayerDeath?.Invoke(); // ? means not null, creates event and fires it
//        }
//    }
//}
