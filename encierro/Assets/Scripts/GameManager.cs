using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public GameObject m_score;

    [SerializeField]
    public TextMeshProUGUI m_speedIncreaseText;

    private int scoreIncrement = 1;
    public float m_currentSpeed = 4f;
    public float m_rateOfSpeedIncrease = 2.0f;
    public float m_maxSpeed = 15.0f;
    bool m_canIncreaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate Objects

        StartCoroutine(IncreaseScore());
    }

    // Update is called once per frame
    void Update()
    {
        // Increase Speed Every 50 Points
        if (m_score.GetComponent<Score>().GetScore() % 100 == 0 && m_score.GetComponent<Score>().GetScore() != 0)
        {
            if (m_currentSpeed < m_maxSpeed && m_canIncreaseSpeed)
            {
                m_canIncreaseSpeed = false;
                Debug.Log("IncreaseSpeed : " + m_currentSpeed);
                IncreaseLevelSpeed();
                StartCoroutine(displayText());
            }
        }
        // random event every 500 points
        if (m_score.GetComponent<Score>().GetScore() % 100 == 0)
        {
            TriggerEvent();
        }
        
    }
    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(0.1f);
        m_canIncreaseSpeed = true;
        m_score.GetComponent<Score>().SetScore(scoreIncrement);
        StartCoroutine(IncreaseScore());
    }

    IEnumerator displayText()
    {
        Debug.Log("DisplayText");
        m_speedIncreaseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        m_speedIncreaseText.gameObject.SetActive(false);
    }

    public ref int GetScore()
    {
        return ref m_score.GetComponent<Score>().score;
    }

    private void TriggerEvent()
    {
        int temp_randomNumber = Random.Range(0, 3);
        if (temp_randomNumber == 0)
        {
            Debug.Log("Train Event");
            // train event 
        }
        else if (temp_randomNumber == 1)
        {
            Debug.Log("Gas Event");
            // Spawn Gas Mask
            // Gas Event
        }
        else if (temp_randomNumber == 2)
        {
            Debug.Log("Dark Event");
            // Dark event
        }
    }

    private void IncreaseLevelSpeed()
    {
        m_currentSpeed += m_rateOfSpeedIncrease;
    }
}
