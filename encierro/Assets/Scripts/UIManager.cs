using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject GameOverMenu;
    public GameObject m_player;


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("TestPatrick");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quitgame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
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
            GameOverMenu.SetActive(true);
    }


}
