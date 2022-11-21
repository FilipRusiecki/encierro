using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject gameOverMenu;

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
            Collision.OnPlayerDeath += EnableGameOvermenu;
    }

    private void OnDisable()
    {
            Collision.OnPlayerDeath -= EnableGameOvermenu;
    }

    // event action has to have void return type and take no arguments

    public void EnableGameOvermenu()
    {
        gameOverMenu.SetActive(true);
    }


}
