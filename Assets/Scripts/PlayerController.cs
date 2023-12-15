using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;




//clase que hereda de MonoBehaviour
public class PlayerControler : MonoBehaviour
{
    private const string V = "Points: ";
    //public TMP_Text countText;
    public float speed;
    private Rigidbody rb;



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
        if (transform.position.y < 0.1)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput > 0)
            {
                Vector3 currentPosition = transform.position;
                float newXPosition = currentPosition.x - (speed * Mathf.Abs(horizontalInput) * Time.deltaTime);
                transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);
            }
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
