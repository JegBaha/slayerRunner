using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollableObstacle : MonoBehaviour
{
    playerMov _playerMov;
    [SerializeField] BoxCollider _collider;
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

            if (_playerMov.isInRoll)
            {
               
                _collider.enabled = false;
            }else if (!_playerMov.isInRoll)
            {
                _playerMov.Die();
            }
           
           
        }
    }
}
