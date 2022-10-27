using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementz;
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 gravity;
    [SerializeField]
    private Vector3 jumpForce;
    bool isGrounded = false;


    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        Physics.gravity = gravity;
    }

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
   

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementz = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0, movementz);
        rb.AddForce(movement*speed*Time.deltaTime, ForceMode.Force);

       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = jumpForce;
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerCoins = +1;
            audioSource.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        
    }
}
