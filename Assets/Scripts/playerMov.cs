using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMov : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _horizontalInpt;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] bool aliveThing = true;
    [SerializeField] public bool _dsahAble=false;
    [SerializeField] private float jumpPadFore = 800f;
    [SerializeField] private float jumpForce = 2500f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isMoveAble = true;
    [SerializeField] private Animator playerAnim;
    [SerializeField] public bool isInRoll = false;
 
    [SerializeField] private TextMeshProUGUI scoreText;
    score _score;
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {
        updateMovThing();
   
    }
    
    private void FixedUpdate()
    {
        if(isMoveAble)
            fixedMovThing();
     
    }
    private void fixedMovThing()
    {
        if (!aliveThing) return;
        Vector3 forwardMov = transform.forward * _speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * _horizontalInpt * _horizontalSpeed*Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + forwardMov+horizontalMove);
   
    }
 
    private void updateMovThing()
    {
     
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        _horizontalInpt = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(dashThing());
        }
        if (transform.position.y < -5)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {

            StartCoroutine(jumpThing());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            rollThing();
     


        }
        if (playerAnim == null)
        {
           
            playerAnim.Play("Two Cycle Sprint");
        }
    }
    public void Die()
    {
        aliveThing = false;
    
        Invoke("Restart", 2);
           }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void rollThing()
    {
        playerAnim.Play("rollThing");
        StartCoroutine(rollFuncThing());
    }
    private IEnumerator dashThing()
    {
        _speed = 15f;
        _dsahAble = true;
        yield return new WaitForSeconds(1.0f);
        _dsahAble = false;
        _speed = 11f;
        StopCoroutine(dashThing());
    }
    public void jumpPadFuncThing()
    {
        _rb.AddForce(Vector3.up*jumpPadFore);
    }
    
    private IEnumerator jumpThing()
    {
        _rb.AddForce(Vector3.up * jumpForce*1.5f);
        yield return new WaitForSeconds(2.0f);
        StopCoroutine(jumpThing()); 
    }
    public IEnumerator grabAbleThing()
    {
        isMoveAble = false;
        yield return new WaitForSeconds(0.5f);
        isMoveAble = true;
        _rb.AddForce(Vector3.forward+Vector3.up * jumpForce);
        yield return new WaitForSeconds(0.5F);
        StopCoroutine(grabAbleThing());
    }
    private  IEnumerator rollFuncThing()
    {
        isInRoll = true;
        yield return new WaitForSeconds(1.5f);
        isInRoll= false;
        StopCoroutine(rollFuncThing());
    }
   
}
