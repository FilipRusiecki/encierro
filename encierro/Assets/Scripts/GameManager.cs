using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public List<GameObject> gameEvents;
    public Light2D roomLight;
    public GameObject[] lights;
    bool darkEventOn = false;
    bool turnOffLightsOnce = false;
    [Header("Positions Off Screen")]
    public List<Transform> Transforms;

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


        //dark event
        if (darkEventOn == true)
        {
;

            if (turnOffLightsOnce == false)
            {
                turnOffLightsOnce = true;
                StartCoroutine(spawnDarkEvent());
            }
        }
    }

    public void spawnInTorch()
    {
        int randomPickSpawn = Random.Range(0, 2);
        if (randomPickSpawn == 0)
        {
            Instantiate(gameEvents[1], Transforms[0].transform.position, Transforms[0].transform.rotation);
        }
        else if (randomPickSpawn == 1)
        {
            Instantiate(gameEvents[1], Transforms[1].transform.position, Transforms[1].transform.rotation);
        }
    }

    IEnumerator spawnDarkEvent()
    {
       // Debug.Log("Dark Event is true");
        GetComponent<SpawnManager>().spawnInTorch();
        yield return new WaitForSeconds(3.0f);

        //Debug.Log(" calls event 2 in courtine ");

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        roomLight.color = new Color(0f,0f,0f,255f);
        yield return new WaitForSeconds(3.0f);


        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);

        }
        roomLight.color = Color.white;
        darkEventOn = false;
        turnOffLightsOnce = false;
       // enable.torchPickedUp = false;
        Debug.Log(" end call event 2 in courtine ");

    }


    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(0.1f);
        m_canIncreaseSpeed = true;
        m_score.GetComponent<Score>().SetScore(scoreIncrement);
        if (m_score.GetComponent<Score>().GetScore() % 50 == 0 && m_score.GetComponent<Score>().GetScore() != 0)
        {
            Debug.Log("TrigeerEvent");
            TriggerEvent();
        }
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
        //int temp_randomNumber = Random.Range(0, 3);
        int temp_randomNumber = 0;
        if (temp_randomNumber == 0)
        {
            Debug.Log("Darkness");
            darkEventOn = true;
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
