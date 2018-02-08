using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : MonoBehaviour {

    public Goo goo;
    public List<string> heldKeys = new List<string>();
    public List<string> neededKeys;
    private int correctButtons;
    public List<GameObject> keys;

    void Start() {
        GenerateKeys();
    }

    void Update() {
        if (Input.inputString != "" && Input.anyKeyDown) {
            heldKeys.Add(Input.inputString);
            CheckKeys();
        }
        
        for (int i = 0; i < heldKeys.Count; i++) {
            if (heldKeys[i].Length > 1 || Input.inputString == "0"
                                       || Input.inputString == "1"
                                       || Input.inputString == "2"
                                       || Input.inputString == "3"
                                       || Input.inputString == "4"
                                       || Input.inputString == "5"
                                       || Input.inputString == "6"
                                       || Input.inputString == "7"
                                       || Input.inputString == "8"
                                       || Input.inputString == "9") {
                heldKeys.Remove(heldKeys[i]);
            }
            else if (Input.GetKeyUp(heldKeys[i])) {
                int index = neededKeys.IndexOf(heldKeys[i]);
                SpriteRenderer sr = keys[index].GetComponent<SpriteRenderer>();
                sr.sprite = Resources.Load("Keys/" + neededKeys[index], typeof(Sprite)) as Sprite;
                heldKeys.Remove(heldKeys[i]);
            }
        }
    }
    
    void CheckKeys() {
        //for all buttons needed
        for (int i = 0; i < heldKeys.Count; i++) {
            //check if buttons are equal
            if (neededKeys.Contains(heldKeys[i])) {
                correctButtons++;

                //Make sprite glow when it is pressed
                int index = neededKeys.IndexOf(heldKeys[i]);
                SpriteRenderer sr = keys[index].GetComponent<SpriteRenderer>();
                sr.sprite = Resources.Load("Keys/" + neededKeys[index] + "_press", typeof(Sprite)) as Sprite;
                }
        }

        if (correctButtons == neededKeys.Count) {
            DoMopping();
        }
        correctButtons = 0;
    }

    void DoMopping() {
        Debug.Log("Correct keys!");
        goo.level -= 0.4f;
        heldKeys.Clear();
        GenerateKeys();
    }

    void GenerateKeys() {
        neededKeys.Clear();
        //generate a few random chars
        int amount;
        if (goo.level >= 1) {
            amount = Random.Range(3, 6);
        } else if (goo.level >= 2.5) {
            amount = Random.Range(4, 8);
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

        for (int i = 0; i < keys.Count; i++) {
            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            sr.sprite = null;
        }

        for (int i = 0; i < neededKeys.Count; i++) {

            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load("Keys/" + neededKeys[i], typeof(Sprite)) as Sprite;

            keys[i].name = neededKeys[i];
        }
    }
}
