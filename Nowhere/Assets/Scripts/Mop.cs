using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : MonoBehaviour {

    public Goo goo;
    public List<string> heldKeys = new List<string>();
    public List<string> neededKeys;
    private int correctButtons;


    void Start() {
        GenerateKeys();
    }

    void Update() {
        if (Input.inputString != "" && Input.anyKeyDown) {
            heldKeys.Add(Input.inputString);
            CheckKeys();
        }

        for (int i = 0; i < heldKeys.Count; i++) {
            if (heldKeys[i].Length > 1 || Input.inputString != "0"
                                       || Input.inputString != "1"
                                       || Input.inputString != "2"
                                       || Input.inputString != "3"
                                       || Input.inputString != "4"
                                       || Input.inputString != "5"
                                       || Input.inputString != "6"
                                       || Input.inputString != "7"
                                       || Input.inputString != "8"
                                       || Input.inputString != "9") {
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

        if (correctButtons == neededKeys.Count) {
            DoMopping();
        }
        correctButtons = 0;
    }

    void DoMopping() {
        Debug.Log("Correct keys!");
        goo.level -= 0.2f;
        heldKeys.Clear();
        GenerateKeys();
    }

    void GenerateKeys() {
        neededKeys.Clear();
        //generate a few random chars
        int amount;
        if (goo.level >= 1) {
            amount = Random.Range(3, 7);
        } else if (goo.level >= 3) {
            amount = Random.Range(4, 9);
        } else {
            amount = Random.Range(2, 5);
        }
        for (int i = 0; i < amount; i++) {
            char c = (char)('a' + Random.Range (0,26));

            //avoid double chars
            bool included = false;
            for (int j = 0; j < neededKeys.Count; j++) {
                if (c.ToString() == neededKeys[j]) {
                   included = true;
                } else {
                   included = false;
                }
            }

            if (!included) {
                neededKeys.Add(c.ToString());
            }
        }
    }
}
