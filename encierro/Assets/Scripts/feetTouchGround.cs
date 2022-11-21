using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feetTouchGround : MonoBehaviour
{
    public player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.isGrounded = true;
            player.jumpCount = 0;
            // player.animator.SetBool("isGrounded", true);
        }
    }

}