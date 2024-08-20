using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalObstacle : MonoBehaviour
{
    playerMov _playerMov;
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

            }
            else
            {
                _playerMov.Die();
            }
        }
    }
}
