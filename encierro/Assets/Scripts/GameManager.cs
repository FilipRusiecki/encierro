using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_obstacle;
    [SerializeField]
    GameObject m_score;
    [SerializeField]
    GameObject m_floor;
    [SerializeField]
    GameObject m_floorTwo;
    [SerializeField]
    GameObject m_backGround;
    [SerializeField]
    GameObject m_backGroundTwo;
    [SerializeField]
    GameObject m_bat;

    private int scoreIncrement = 1;
    private float m_currentSpeed = 2f;
    private int temp = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate Objects
        m_floor = Instantiate(m_floor);
        m_floorTwo = Instantiate(m_floor);
        m_obstacle = Instantiate(m_obstacle);
        m_backGround = Instantiate(m_backGround);
        m_backGroundTwo = Instantiate(m_backGround);
        m_bat = Instantiate(m_bat);

        // Set Parametres
        m_floorTwo.GetComponent<Scroll>().SetPosition(18.0f);
        m_backGroundTwo.GetComponent<Scroll>().SetPosition(18.0f);
        m_floor.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
        m_floorTwo.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
        m_backGround.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
        m_backGroundTwo.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
        m_obstacle.GetComponent<enemy>().SetSpeed(m_currentSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        temp++;
        if (temp >= 60)
        {
            temp = 0;
            IncreaseScore();
            // Increase Spped Every 50 Points
            if (m_score.GetComponent<Score>().GetScore() % 50 == 0)
            {
                IncreaseLevelSpeed();
            }
            // random event every 500 points
            if (m_score.GetComponent<Score>().GetScore() % 250 == 0)
            {
                TriggerEvent();
            }
        }
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

    private void IncreaseScore()
    {
        m_score.GetComponent<Score>().SetScore(scoreIncrement);
    }

    private void IncreaseLevelSpeed()
    {
        if (m_currentSpeed < 15.0f)
        {
            m_currentSpeed += 1f;
            m_floor.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
            m_floorTwo.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
            m_backGround.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
            m_backGroundTwo.GetComponent<Scroll>().SetSpeed(m_currentSpeed);
            m_obstacle.GetComponent<enemy>().SetSpeed(m_currentSpeed);
        }
    }
}
