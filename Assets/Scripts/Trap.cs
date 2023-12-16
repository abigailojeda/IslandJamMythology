using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    //void Start() {
    //    gameObject.SetActive(false);
    //}

    private void Awake() {
        Debug.Log("trap awakened");
        //Audio.instance.PlaySFX("Spikes");
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Has muerto");
        }
    }
}
