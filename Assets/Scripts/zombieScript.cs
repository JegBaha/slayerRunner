using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    playerMov _playerMov;
    [SerializeField] private Transform InterectorSource;
    [SerializeField] private float InteractRange;
    [SerializeField] public Animator controllerThing;

    interface IInteractable
    {
        public void Interact()
        {
        
        }

    }

    void Start()
    {
        _playerMov = GameObject.FindObjectOfType<playerMov>();
    }

    void Update()
    {
        rayThing();
    }
    private void rayThing()
    {
        Ray rayT = new Ray(InterectorSource.position, InterectorSource.forward);
        if (Physics.Raycast(rayT, out RaycastHit hitThing, InteractRange))
        {
            if (hitThing.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
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
