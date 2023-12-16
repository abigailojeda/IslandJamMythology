using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : MonoBehaviour {

    public GameObject trap;
    private Vector3 trapPositionInitial;
    private Vector3 trapPositionActive;
    private bool isActive;
    private bool isMoving;

    // Start is called before the first frame update
    void Start() {
        isActive = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (isActive == false) {
                //Audio.instance.PlaySFX("TrapSpikesDelay");
                transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);

                Invoke("activate", 1);
            }
        }
    }

    public void activate() {
        Debug.Log("activation happened");
        trap.SetActive(true);
        Invoke("deactivate", 3);
    }

    private void deactivate() {
        Debug.Log("biebie");
        transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
        trap.SetActive(false);
        isActive = false;
    }
}
