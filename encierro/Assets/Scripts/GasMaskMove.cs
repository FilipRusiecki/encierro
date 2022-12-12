using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float scrollSpeed;
    public float _bounds;
    public GameObject _gameObject;

    public GameObject playersGasMask;

    void Start()
    {
        _gameObject = playersGasMask.transform.Find("pickupRadius").gameObject;
    }
    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x < _bounds)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetSpeed(float t_speed)
    {
        scrollSpeed = t_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playersGasMask.transform.Find("PlayerGasMask").gameObject.SetActive(true);
            
            _gameObject.GetComponent<GasMaskPickup>().setUpGasBar();
            Destroy(this.gameObject);
        }
    }
}
