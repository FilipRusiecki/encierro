using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    
    //public GameObject text;
    [Header("Player Jumping")]
    public float jumpForce = 0;
    public int jumpCount = 0;
    public int allowedJumps = 0;
    public bool isGrounded = false;
    public GameObject gameManager;
    public AudioSource audio;
   
    
    //  public Animator animator;
    int speed = 2;

 

    void Start()
    {
        EnablePlayerMovement();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            audio.Play();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("isGrounded", false);
            jumpCount += 1;
            if (jumpCount == allowedJumps)
            {
                isGrounded = false;
            }
        }
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * speed * Time.deltaTime;
        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
           
        }
        if(GetComponent<circleAABB>().isCOlliding==true)
        {
            pushBack();
            if(transform.position.x<-3)
            {
                 GetComponent<circleAABB>().isCOlliding = false;
            }



        }
        if(transform.position.x<-1)
        {
            GetComponent<pullBackCentre>().enabled=true;
        }
        if(transform.position.x>=0)
        {
            GetComponent<pullBackCentre>().enabled = false;
        }

    }

    // add this code to player controller to disable movement when gameoover screen active

    private void OnEnable()
    {
        Collision.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        Collision.OnPlayerDeath -= DisablePlayerMovement;
    }

    private void DisablePlayerMovement()
    {
        //animator.enabled = false;
         rb.bodyType = RigidbodyType2D.Static;
    }

    //call in start
    private void EnablePlayerMovement()
    {
        //animator.enabled = true;
         rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void pushBack()
    {
        rb.AddForce(Vector2.left * 0.09f, ForceMode2D.Impulse);
    }




}