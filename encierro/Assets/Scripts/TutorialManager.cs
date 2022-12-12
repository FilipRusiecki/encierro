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


    // Start is called before the first frame update
    void Start()
    {
        _pause = false;
        _jumpTutorial = false;
        m_obstacle = Instantiate(m_obstacle);
        m_bat = Instantiate(m_bat);
        m_obstacle.GetComponent<Obstacle>().SetSpeed(4);

    }

    // Update is called once per frame
    void Update()
    {
        obstacleTutorial();
    }

    private void obstacleTutorial()
    {
        if (m_obstacle != null)
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
        Debug.Log("Here");
        m_obstacleTutorialText.SetActive(true);
        yield return new WaitForSeconds(_waitTime);

        if (Input.GetKeyDown(KeyCode.Space) && _pause == true)
        {
            _pause = false;
            m_obstacleTutorialText.SetActive(false);
            m_obstacle.GetComponent<Obstacle>().SetSpeed(4);
        }
        else
        {
            Debug.Log("Here2");
            StartCoroutine(displayJumpText(0.0f));
        }
    }
}
