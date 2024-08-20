using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerLoc;
    [SerializeField] private Vector3 _offset;
    void Start()
    {
        _offset = transform.position-_playerLoc.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollowThing();
    }
    
    private void cameraFollowThing(){
        Vector3 targetPos = _playerLoc.position + _offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
