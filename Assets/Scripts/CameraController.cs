using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  GameObject player;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 newPosition = transform.position;
            newPosition.z = player.transform.position.z - 30f;
            transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 newPosition = transform.position;
            newPosition.z = player.transform.position.z;
            transform.position = newPosition;
        }
    }
}
