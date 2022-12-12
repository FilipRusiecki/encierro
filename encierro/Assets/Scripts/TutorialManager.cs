using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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


    // -----------------------------

    public GameObject m_gasMask;
    public GameObject m_gasMaskText;

    public GameObject m_gasField;
    public GameObject m_gasFieldText;


    public GameObject m_torch;
    public GameObject m_battery;
    public GameObject m_batteryTwo;
    public GameObject m_darkEventText;
    public Light2D roomLight;
    public Light2D roofLightOne;
    public Light2D roofLightTwo;

    public GameObject m_chaser;
    public GameObject m_endText;


    private bool _gasTutorial;
    private bool _gasField;
    private bool _gasTutorialComplete;

    private bool _darkTutorial;
    private bool _darkTutorialComplete;
    private bool _lightsOnOff;

    private bool _chaseTutorial;
    private bool _chaseTutorialComplete;

    // ------------------------------

    bool _tutorialFinished;





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
        _chaseTutorial = false;
        _chaseTutorialComplete = false;
        _gasField = false;
        _lightsOnOff = false;

        m_obstacle = Instantiate(m_obstacle);
        m_obstacle.GetComponent<Obstacle>().SetSpeed(4);
        m_bat.SetActive(false);
        m_gasMask.SetActive(false);
        m_gasField.SetActive(false);
        m_torch.SetActive(false);
        m_battery.SetActive(false);
        m_batteryTwo.SetActive(false);
        roomLight.color = Color.white;
        _tutorialFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_tutorialFinished == false)
        {
            obstacleTutorial();
            if (_obstacleTutorialComplete == true && _batTutorialComplete == false)
            {
                _obstacleTutorialComplete = false;
                Debug.Log("Bat");
                StartCoroutine(spawnBat(2.0f));
            }
            if (_batTutorialComplete == true && _gasTutorial == false)
            {
                _batTutorialComplete = false;
                Debug.Log("Gas Tutorial");
                StartCoroutine(spawnGas(2.0f));
            }
            if (_darkTutorial == false && m_gasField == null)
            {
                _darkTutorial = true;
                StartCoroutine(spawnTorchAndBatteries(2.0f));
            }
            // runs after spawn bat
            batTutorial();
            gasTutorial();
            if (_lightsOnOff == false && _darkTutorial == true && _pause ==false)
            {
                darkTutorial();
            }
            if (_lightsOnOff == true)
            {
                Debug.Log("Starttttttttin Again");
                _lightsOnOff = false;
                StartCoroutine(turnLightsOff(2.0f));
            }
        }
    }

    IEnumerator turnLightsOff(float _waitTime)
    {
 
        roomLight.color = Color.black;
        roofLightOne.color = Color.black;
        roofLightTwo.color = Color.black;
        yield return new WaitForSeconds(10.0f);
        roomLight.color = Color.white;
        roofLightOne.color = Color.white;
        roofLightTwo.color = Color.white;
        _darkTutorialComplete = true;
        resetEverything();
        StopCoroutine(turnLightsOff(0.0f));
    }

    private void resetEverything()
    {
        m_endText.SetActive(true);
        _pause = false;
        _jumpTutorial = false;
        _obstacleTutorialComplete = false;
        _batTutorial = false;
        _batTutorialComplete = false;

        _gasTutorial = false;
        _gasTutorialComplete = false;
        _darkTutorial = false;
        _darkTutorialComplete = false;
        _chaseTutorial = false;
        _chaseTutorialComplete = false;
        _gasField = false;
        _lightsOnOff = false;

        m_obstacle = Instantiate(m_obstacle);
        m_obstacle.GetComponent<Obstacle>().SetSpeed(4);
        m_bat.SetActive(false);
        m_gasMask.SetActive(false);
        m_gasField.SetActive(false);
        m_torch.SetActive(false);
        m_battery.SetActive(false);
        m_batteryTwo.SetActive(false);
        roomLight.color = Color.white;
    }

    private void darkTutorial()
    { // problem

        if (_darkTutorial == true)
        {
            if (m_torch != null)
            {
                if (m_torch.transform.position.x <= 1.5f)
                {
                    // Debug.Log("Pausing gas mask");
                    //_gasTutorial = true;
                    _pause = true;
                  //  m_torch.GetComponent<torchPickup>().SetSpeed(0.0f);
                    Debug.Log("Pausing");
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && _pause == true && m_torch.transform.position.x <= 1.5f)
            {
                _pause = false;
                m_darkEventText.SetActive(false);
                _darkTutorial = false;
                m_torch.GetComponent<torchPickup>().SetSpeed(4.0f);
                StopCoroutine(spawnTorchAndBatteries(0.0f));
            }
            else
            {
                _darkTutorial = true;
                //Debug.Log("Here2");
                StartCoroutine(spawnTorchAndBatteries(0.0f));
            }
        }
    }

    IEnumerator spawnTorchAndBatteries(float _waitTime)
    {

        if (m_torch != null)
        {
            // Debug.Log("Spawn Gas COROUT");
            m_gasFieldText.SetActive(false);
            m_torch.SetActive(true);
            m_darkEventText.SetActive(true);
            yield return new WaitForSeconds(_waitTime);

        }
        else
        {
            if (_pause == true)
            {
                _pause = false;
                m_darkEventText.SetActive(false);
                _darkTutorial = false;

                StopCoroutine(spawnTorchAndBatteries(0.0f));
            }
        }
        //yield return new WaitForSeconds(_waitTime);



    }

    private void gasTutorial()
    {
        if (_gasTutorial == true)
        {
            if (m_gasMask.transform.position.x < 1.5f)
            {
                // Debug.Log("Pausing gas mask");
                //_gasTutorial = true;
                _pause = true;
                m_bat.SetActive(false);
            }
            if (_pause == true && m_gasMask.transform.position.x <= 1.5F)
            {
                // Debug.Log("Pausing Herreeeeee");
                m_gasMask.GetComponent<GasMaskMove>().SetSpeed(0.0f);
            }
        }
    }

    IEnumerator spawnGas(float _waitTime)
    {
        if (m_gasMask != null)
        {
           // Debug.Log("Spawn Gas COROUT");
            m_gasMask.SetActive(true);
            m_gasMaskText.SetActive(true);
            yield return new WaitForSeconds(_waitTime);

            if (Input.GetKeyDown(KeyCode.Space) && _pause == true && m_gasMask.transform.position.x <= 1.5f)
            {
                Debug.Log("Stopping spawnGas()");
                _pause = false;
                m_gasMaskText.SetActive(false);
                _gasTutorial = false;
                m_gasField.SetActive(true);
                m_gasFieldText.SetActive(true);
                m_gasMask.GetComponent<GasMaskMove>().SetSpeed(4.0f);
                StopCoroutine(spawnGas(0.0f));
            }
            else
            {
                _gasTutorial = true;
                //Debug.Log("Here2");
                StartCoroutine(spawnGas(0.0f));
            }
        }
        else
        {
            if (_pause == true)
            {
                _pause = false;
                m_gasMaskText.SetActive(false);
                _gasTutorial = false;
                m_gasField.SetActive(true);
                m_gasFieldText.SetActive(true);
                StopCoroutine(spawnGas(0.0f));
            }
        }
    }

    IEnumerator spawnBat(float _waitTime)
    {
        if (m_bat != null)
        {
            m_bat.SetActive(true);
            m_batTutorialText.SetActive(true);
        }
        yield return new WaitForSeconds(_waitTime);

        if (Input.GetKeyDown(KeyCode.Space) && _pause == true && m_bat.transform.position.x <= 3.5f)
        {
            _pause = false;
            _batTutorialComplete = true;
            m_batTutorialText.SetActive(false);
            m_bat.GetComponent<TutorialBat>().speed = 4.0f;
            StopCoroutine(spawnBat(0.0f));
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
