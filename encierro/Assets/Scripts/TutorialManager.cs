using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject m_obstacle;
    public GameObject m_obstacleTutorialText;

    public GameObject m_bat;
    public GameObject m_batTutorialText;

    private bool _pause;
    private bool _jumpTutorial;
    private bool _obstacleTutorialComplete;

    private bool _batTutorial;
    private bool _batTutorialComplete;



    // Start is called before the first frame update
    void Start()
    {
        _pause = false;
        _jumpTutorial = false;
        _obstacleTutorialComplete = false;
        _batTutorial = false;
        _batTutorialComplete = false;
        m_obstacle = Instantiate(m_obstacle);
        m_obstacle.GetComponent<Obstacle>().SetSpeed(4);
        m_bat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_obstacleTutorialComplete == true && _batTutorialComplete == false)
        {
            _obstacleTutorialComplete = false;
            Debug.Log("Bat");
            StartCoroutine(spawnBat(2.0f));
        }
        if(_batTutorialComplete == true)
        {
            Debug.Log("Gas Tutorial");
        }
        obstacleTutorial();
        batTutorial();
    }

    IEnumerator spawnBat(float _waitTime)
    {
        Debug.Log("Here");
        m_bat.SetActive(true);
        m_batTutorialText.SetActive(true);
        yield return new WaitForSeconds(_waitTime);

        if (Input.GetKeyDown(KeyCode.Space) && _pause == true && m_bat.transform.position.x <= 3.5f)
        {
            _pause = false;
            _batTutorialComplete = true;
            m_batTutorialText.SetActive(false);
            m_bat.GetComponent<TutorialBat>().speed = 4.0f;
            StopCoroutine(displayJumpText(0.0f));
        }
        else
        {
            Debug.Log("Here2");
            StartCoroutine(spawnBat(0.0f));
        }
    }

    private void batTutorial()
    {
        if (m_bat != null)
        {
            if (m_bat.transform.position.x < 3.5f && _batTutorial == false)
            {
                Debug.Log("PausingBat");
                _batTutorial = true;
                _pause = true;
            }
            if (_pause == true && m_bat.transform.position.x <= 3.5f)
            {
                m_bat.GetComponent<TutorialBat>().speed =0.0f;
            }
        }
    }

    private void obstacleTutorial()
    {
        if (m_obstacle != null && _obstacleTutorialComplete == false)
        {
            if (m_obstacle.transform.position.x < 3.5f && _jumpTutorial == false)
            {

                _jumpTutorial = true;
                _pause = true;
                StartCoroutine(displayJumpText(2.0f));
            }
            if (_pause == true)
            {
                m_obstacle.GetComponent<Obstacle>().SetSpeed(0);
            }
        }
    }

    IEnumerator displayJumpText(float _waitTime)
    {
        Debug.Log("Old CoRoutine");
        // Debug.Log("Here");
        m_obstacleTutorialText.SetActive(true);
        yield return new WaitForSeconds(_waitTime);

        if (Input.GetKeyDown(KeyCode.Space) && _pause == true)
        {
            _pause = false;
            m_obstacleTutorialText.SetActive(false);
            _obstacleTutorialComplete = true;
            m_obstacle.GetComponent<Obstacle>().SetSpeed(4);
            StopCoroutine(displayJumpText(0.0f));
        }
        else
        {
         //   Debug.Log("Here2");
            StartCoroutine(displayJumpText(0.0f));
        }
    }
}
