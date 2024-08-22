using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    playerMov _playerMov;
    void Start()
    {
        _playerMov=GameObject.FindObjectOfType<playerMov>();    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _playerMov.Die();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
