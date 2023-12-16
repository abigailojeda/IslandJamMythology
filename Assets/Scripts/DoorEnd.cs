using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnd : MonoBehaviour {

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (object1.activeSelf == false) {
                Debug.Log("Te faltó el objeto 1");
            }
            if (object2.activeSelf == false) {
                Debug.Log("Te faltó el objeto 2");
            }
            if (object3.activeSelf == false) {
                Debug.Log("Te faltó el objeto 3");
            } else {
                Debug.Log("CAGASTE");
            }
        }
    }
}
