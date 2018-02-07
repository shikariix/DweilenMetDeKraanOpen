using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : MonoBehaviour {

    public Goo goo;
    public List<string> heldKeys = new List<string>();
    public List<string> neededKeys;
    private int correctButtons;

    void Update() {
        if (Input.inputString != "" && Input.anyKeyDown) {
            heldKeys.Add(Input.inputString);
            CheckKeys();
        }

        for (int i = 0; i < heldKeys.Count; i++) {
            if (heldKeys[i].Length > 1) {
                heldKeys.Remove(heldKeys[i]);
            }
            else if (Input.GetKeyUp(heldKeys[i])) {
                heldKeys.Remove(heldKeys[i]);
            }
        }
    }

    void CheckKeys() {
        //for all buttons needed
        for (int i = 0; i < heldKeys.Count; i++) {
            //check if buttons are equal
            if (neededKeys[i] == heldKeys[i]) {
                correctButtons++;
            }
        }
        Debug.Log(correctButtons);

        if (correctButtons == neededKeys.Count) {
            DoMopping();
        }
        correctButtons = 0;
    }
    void DoMopping() {
        Debug.Log("Correct keys!");
        heldKeys.Clear();
    }
}
