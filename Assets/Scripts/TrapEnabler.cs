using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : MonoBehaviour {

    public GameObject trap;
    public int pushSide; // 1 xup 2 xdown, 3 zup, 4 zdown
    private Vector3 trapPositionInitial;
    private Vector3 trapPositionActive;
    private bool isActive;
    private bool isMoving;

    // Start is called before the first frame update
    //void Start() {
    //    isActive = false;
    //}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //if (isActive == false) {
            //    //Audio.instance.PlaySFX("TrapSpikesDelay");
            //    if (pushSide == 1) { transform.position = new Vector3(transform.position.x + 4f, transform.position.y, transform.position.z); }
            //    else if (pushSide == 2) { transform.position = new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z); }
            //    else if (pushSide == 3) { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4f); }
            //    else { transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z - 4f); }

            //    Invoke("activate", 1);
            //}

            trap.transform.position = new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z);
            Invoke("activate", 1);
        }
    }

    public void activate() {
        Debug.Log("activation happened");
        Invoke("deactivate", 3);
    }

    private void deactivate() {
        Debug.Log("biebie");
        //if (pushSide == 1) { transform.position = new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z); }
        //else if (pushSide == 2) { transform.position = new Vector3(transform.position.x + 4f, transform.position.y, transform.position.z); }
        //else if (pushSide == 3) { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f); }
        //else { transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z + 4f); }

        trap.transform.position = new Vector3(transform.position.x + 4f, transform.position.y, transform.position.z);
        isActive = false;
    }
}
