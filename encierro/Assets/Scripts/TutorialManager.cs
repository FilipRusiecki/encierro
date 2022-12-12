using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject m_obstacle;
    public GameObject m_obstacleTutorialText;

    public GameObject m_bat;
    public GameObject m_batTutorialText;


    public GameObject m_gasMask;
    public GameObject m_gasMaskText;


    public GameObject m_gasField;
    public GameObject m_gasFieldText;


    public GameObject m_torch;
    public GameObject m_battery;
    public GameObject m_darkEventText;

    public GameObject m_chaser
    public GameObject m_chaserText


    private bool _pause;
    private bool _jumpTutorial;
    private bool _obstacleTutorialComplete;

    private bool _batTutorial;
    private bool _batTutorialComplete;

    private bool _gasTutorial;
    private bool _gasTutorialComplete;

    private bool _darkTutorial;
    private bool _darkTutorialComplete;

    private bool _chaseTutorial;
    private bool _chaseTutorialComplete;



    // Start is called before the first frame update
    void Start()
    {
        _pause = false;
        _jumpTutorial = false;
        _obstacleTutorialComplete = false;
        _batTutorial = false;
        _batTutorialComplete = false;

_gasTutorial = false;
        _gasTutorialComplete = false;
_darkTutorial = false;
        _darkTutorialComplete = false;
_chasingTutorial = false;
        _chasingTutorialComplete = false;


        m_obstacle = Instantiate(m_obstacle);
        m_obstacle.GetComponent<Obstacle>().SetSpeed(4);
        m_bat.SetActive(false);
        m_gasMask.SetActive(false)
m_gasField.SetActive(false)
m_torch.SetActive(false)
m_battery.SetActive(false)
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
        if(_batTutorialComplete == true && _gasTutorial == false)
        {
            Debug.Log("Gas Tutorial");
StartCoroutine(spawnGas(2.0f));
        }
        obstacleTutorial();
        batTutorial();
        gasTutorial()
    }

    IEnumerator spawnGas(float _waitTime)
{
   m_gasMask.SetActive(true)
m_gasTutorialText.SetActive(true);
yield return new WaitForSeconds(_waitTime);
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

   private void gasTutorial()
{

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
