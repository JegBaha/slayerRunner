using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabable : MonoBehaviour
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
            StartCoroutine(_playerMov.grabAbleThing());


        }
        else
        {
            Destroy(gameObject);
        }
    }
}
