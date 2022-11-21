using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public GameObject gameOverMenu;
    public bool isPlayerAlive;

    void Start()
    {
        isPlayerAlive = true;
    }

    void Update()
    {
        if (isPlayerAlive == false)
        {
            Debug.Log("Here");
            OnPlayerDeath?.Invoke(); // ? means not null, creates event and fires it
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        if (!isPlayerAlive)
        {
            OnPlayerDeath += EnableGameOvermenu;
        }
    }

    private void OnDisable()
    {
        if (isPlayerAlive)
        {
            OnPlayerDeath -= EnableGameOvermenu;
        }
    }

    // event action has to have void return type and take no arguments

    public void EnableGameOvermenu()
    {
        gameOverMenu.SetActive(true);
    }

    // add this code to player controller

    //private void DisablePlayerMovement()
    //{
    //    animator.enabled = false;
    //    // rb.bodyType = RigidbodyType2D.Static;
    //}

    ////call in start
    //private void EnablePlayerMovement()
    //{
    //    animator.enabled = true;
    //    // rb.bodyType = RigidbodyType2D.Dynamic;
    //}

    // private void OnEnable()
    //{
    // Collision.OnPlayerdeath += DisablePlayerMovement;
    //}

    // private void OnDisable()
    //{
    // Collision.OnPlayerdeath -= DisablePlayerMovement;
    //}
}
