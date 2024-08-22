using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalObstacle : MonoBehaviour
{
    playerMov _playerMov;
    [SerializeField] private GameObject _explosion;
    void Start()
    {
        _playerMov = GameObject.FindObjectOfType<playerMov>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            if (_playerMov._dsahAble)
            {
               gameObject.SetActive(false);
                Instantiate(_explosion, this.gameObject.transform);
               

            }
            else
            {
                _playerMov.Die();
            }
        }
    }
}
