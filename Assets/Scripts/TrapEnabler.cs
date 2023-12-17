using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEnabler : MonoBehaviour {

    public GameObject trap;
    public float trapX, trapZ;

    private Vector3 trapPositionInitial;
    private bool isPressed;

    private void Awake() {
        trapPositionInitial = trap.transform.position;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (isPressed == false) {
                //Audio.instance.PlaySFX("TrapSpikesDelay");
                Invoke("activate", 1);
                isPressed = true;
            }
        }
    }

    public void activate() {
        //Audio.instance.PlaySFX("TrapSpikesActive");
        trap.transform.position = new Vector3(trapX, trap.transform.position.y, trapZ);
        Invoke("deactivate", 3);
    }

    public void deactivate() {
        //Audio.instance.PlaySFX("TrapSpikesDeactive");
        trap.transform.position = trapPositionInitial;
        isPressed = false;
    }
}
