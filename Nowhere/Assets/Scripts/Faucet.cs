using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour {

    public Goo goo;
    public bool isOpen = false;
    private int random;

    void Update() {
        random = Random.Range(0, 1000);
        if (random == 7 && !isOpen) {
            OpenFaucet();
        }

        if (isOpen) {
            goo.level += 0.0005f;
        }
    }

    void OpenFaucet() {
        isOpen = true;
        Debug.Log("Faucet Opened");
    }
}
