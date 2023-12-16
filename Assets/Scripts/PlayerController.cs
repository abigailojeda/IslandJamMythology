using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerControler : MonoBehaviour
{


    public float speed;
    public float rotationSpeed  =180.0f;
    public float jumpForce;
    private Rigidbody rb;

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;





    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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

        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * rotationSpeed, 0));
    }


    void Jump()
    {

        if (transform.position.y < 0)
        {

            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Pickup1")
        {
            object1.SetActive(true);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Pickup2")
        {
            object2.SetActive(true);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Pickup3")
        {
            object3.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

}