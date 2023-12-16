using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject door;
    public GameObject doorDown;
    public Animator animator;
    public Animator animatorDown;

    public void Start()
    {
        animator = door.GetComponent<Animator>();
        animatorDown = doorDown.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (transform.CompareTag("Door1"))
            {
                animator.SetBool("door1", true);
                animatorDown.SetBool("door1down", true);
            }
        }
    }

}
