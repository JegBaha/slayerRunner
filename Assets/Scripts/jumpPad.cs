using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    // Start is called before the first frame update
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

            _playerMov.jumpPadFuncThing();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            _playerMov.jumpPadFuncThing();
        }
    }
}
