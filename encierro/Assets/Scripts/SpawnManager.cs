using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _obstaclePrefab;
    [SerializeField]
    GameObject _batPrefab;
    [SerializeField]
    GameObject _floorPrefab;
    [SerializeField]
    GameObject _wallPrefab;
    [SerializeField]
    GameObject _lightPrefab;

    private GameObject _obstacle; 
    private GameObject _bat;
    private GameObject _floorOne;
    private GameObject _floorTwo;
    private GameObject _wallOne;
    private GameObject _wallTwo;

    public int _noOfBats = 0;
    public float _spawnTime = 3.0f;
    bool m_canDecreaseSpawnTime = false;

    // Start is called before the first frame update
    void Start()
    {
        _spawnTime = 3.0f;
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<GameManager>().GetScore() % 50 == 0 && GetComponent<GameManager>().GetScore() != 0)
        {
            if (_spawnTime > 0.5f && m_canDecreaseSpawnTime)
            {
                m_canDecreaseSpawnTime = false;
                _spawnTime = _spawnTime - 0.25f;
            }
        }
        _floorOne.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        _floorTwo.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        _wallOne.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        _wallTwo.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObstacle();
            if(_bat == null)
            {
                SpawnBat();
            }
            if (_floorOne == null && _floorTwo == null)
            {
                SpawnFloors();
            }
            if (_wallOne == null && _wallTwo == null)
            {
                SpawnWalls();
            }
            yield return new WaitForSeconds(_spawnTime);
            m_canDecreaseSpawnTime = true;
        }
    }

    void SpawnFloors()
    {
        _floorOne = Instantiate(_floorPrefab, new Vector3(0.0f,-4.5f,0.0f), Quaternion.identity);
        _floorTwo = Instantiate(_floorPrefab, new Vector3(18.0f, -4.5f, 0.0f), Quaternion.identity);
        _floorOne.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        _floorTwo.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
    }

    void SpawnWalls()
    {
        _wallOne = Instantiate(_wallPrefab, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
        _wallTwo = Instantiate(_wallPrefab, new Vector3(18.0f, 0.5f, 0.0f), Quaternion.identity);
        _wallOne.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        _wallTwo.GetComponent<Scroll>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
    }

    void SpawnObstacle()
    {
        Vector3 _spawnPosition = new Vector3(Random.Range(10.0f, 16.0f), -3.5f, 0.0f);
        _obstacle = Instantiate(_obstaclePrefab, _spawnPosition, Quaternion.identity);
        _obstacle.GetComponent<Obstacle>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        if (_spawnTime <= 2.0f)
        {
            _spawnPosition = new Vector3(Random.Range(10.0f, 16.0f), -3.5f, 0.0f);
            _obstacle = Instantiate(_obstaclePrefab);
            _obstacle.GetComponent<Obstacle>().SetSpeed(GetComponent<GameManager>().m_currentSpeed);
        }
    }

    void SpawnBat()
    {
        _noOfBats++;
        Vector3 _spawnPosition = new Vector3(Random.Range(10.0f, 12.0f), -3.5f, 0.0f);
        _bat = Instantiate(_batPrefab);
    }

    public void DecreaseNoOfBats()
    {
        Debug.Log("Bats Worked");
        _noOfBats--;
    }
}
