using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerControler : MonoBehaviour
{
    //private const string V = "Points: ";
    //public TMP_Text countText;
    public float speed;
    public float jumpForce;
    private  Rigidbody rb;



   // private float movementX;
   // private float movementY;
   // private float movementJump;

   // private int count;

    // Start is called before the first frame update
    void Start()
    {
        //onInit 
        rb = GetComponent<Rigidbody>();
        //count = 0;
       // movementJump = 0;

        //to hide button
        //backButton.SetActive(true);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Saltar");
            Jump();
        }

        Vector3 direction = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        velocity = direction * speed;

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }


    void Jump()
    {
     
        if(transform.position.y< 0)
        {

        rb.AddForce(Vector3.up * jumpForce);
        }
    }


    //To collide pickups
    //private void OnTriggerEnter(Collider other)
    //{
    //    other.gameObject.SetActive(false);
    //    count++;


    //    setText();
    //}

    //private void setText()
    //{
    //    if (count < 10)
    //    {
    //        countText.text = V + count.ToString() + "/10";
    //    }
    //    else
    //    {
    //        countText.text = "You win!! :) " + count.ToString() + "/10";


    //    }

    //}


    //to move sphere
    //private void OnMove(InputValue movementValue)
    //{
    //    Vector2 movement = movementValue.Get<Vector2>();

    //    movementX = movement.x;
    //    movementY = movement.y;

    //}

    //to jump
    //private void OnJump()
    //{
    //    if (transform.position.y <= 2.61)
    //    {
    //        movementJump = 50;
    //    }


    //}


    // Update is called once per frame
    //before calculate physic
    //void FixedUpdate()
    //{
    //    //executed on each frame
    //    Vector3 movement = new Vector3(movementX, movementJump, movementY);
    //    rb.AddForce(movement * speed);
    //    movementJump = 0;

    //}


}
