using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static score Instence;
    playerMov _playerMov;
    [SerializeField] public int currentScore = 0;
    [SerializeField] private float animateSpeed = 90f;
    void Start()
    {
        Instence = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, animateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            return;
        }
        else
        {
            
            Destroy(this.gameObject);
        }
       

    }

}
