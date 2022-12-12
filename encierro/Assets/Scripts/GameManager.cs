using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    // ________________ Light Event Objects

    public List<GameObject> gameEvents;
    public Light2D roomLight;
    public GameObject[] lights;
    bool darkEventOn = false;
    bool gasEventOn = false;
    bool turnOffLightsOnce = false;


    // ________________ Gas Event Objects
    bool _maskSpawned = false;
    bool _gasFieldSpawned = false;


    [Header("Positions Off Screen")]
    public List<Transform> Transforms;

    [SerializeField]
    public GameObject m_score;

    [SerializeField]
    public TextMeshProUGUI m_speedIncreaseText;

    private int scoreIncrement = 1;
    public float m_currentSpeed = 4f;
    public float m_rateOfSpeedIncrease = 1.25f;
    public float m_maxSpeed = 15.0f;
    bool m_canIncreaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
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
                IncreaseLevelSpeed();
                StartCoroutine(displayText());
            }
        }

        if (darkEventOn == true)
        {
            if (turnOffLightsOnce == false)
            {
                turnOffLightsOnce = true;
                StartCoroutine(spawnDarkEvent());
            }
        }
        if (gasEventOn == true)
        {
            if (!_maskSpawned)
            {
                _maskSpawned = true;
                GetComponent<SpawnManager>().spawnInGasMask();
            }
            else if (!_gasFieldSpawned)
            {
                _gasFieldSpawned = true;
                StartCoroutine(spawnInGasField());
            }
        }
    }

    IEnumerator spawnDarkEvent()
    {
        if (!GetComponent<SpawnManager>()._torchSpawned)
        {
            GetComponent<SpawnManager>().spawnInTorch();
        }
        else
        {
            GetComponent<SpawnManager>().spawnInBatteries();
        }
        yield return new WaitForSeconds(4.0f);

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        roomLight.color = new Color(0f, 0f, 0f, 255f);
        yield return new WaitForSeconds(6.0f);

        GetComponent<SpawnManager>().spawnInBatteries();

        yield return new WaitForSeconds(4.0f);


        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);

        }
        roomLight.color = Color.white;
        darkEventOn = false;
        turnOffLightsOnce = false;
    }


    IEnumerator spawnInGasField()
    {
        yield return new WaitForSeconds(3.0f);
        GetComponent<SpawnManager>().spawnInGasField();
        yield return new WaitForSeconds(5.0f);
        gasEventOn = false;
        _maskSpawned = false;
        _gasFieldSpawned = false;
    }

    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(0.1f);
        m_canIncreaseSpeed = true;
        m_score.GetComponent<Score>().SetScore(scoreIncrement);
        if (m_score.GetComponent<Score>().GetScore() % 150 == 0 && m_score.GetComponent<Score>().GetScore() != 0)
        {
            TriggerEvent();
        }
        StartCoroutine(IncreaseScore());
    }

    IEnumerator displayText()
    {
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
        int temp_randomNumber = Random.Range(0, 2);
        
        if (temp_randomNumber == 0)
        {
            Debug.Log("Darkness");
            darkEventOn = true;
        }
        else if (temp_randomNumber == 1)
        {
            Debug.Log("Gas Event");
            gasEventOn = true;
        }
    }

    private void IncreaseLevelSpeed()
    {
        m_currentSpeed += m_rateOfSpeedIncrease;
    }
}
