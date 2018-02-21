using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mop : MonoBehaviour {

    public Goo goo;
    public List<string> heldKeys = new List<string>();
    public List<string> neededKeys;
    private int correctButtons;
    public List<GameObject> keys;

    public Animator anim;
    public AudioSource aud;

    void Start() {
        GenerateKeys();
    }

    void Update() {
        if (Input.inputString != "" && Input.anyKeyDown
                                    && Input.inputString.Length == 1
                                    && Input.inputString != "0"
                                    && Input.inputString != "1"
                                    && Input.inputString != "2"
                                    && Input.inputString != "3"
                                    && Input.inputString != "4"
                                    && Input.inputString != "5"
                                    && Input.inputString != "6"
                                    && Input.inputString != "7"
                                    && Input.inputString != "8"
                                    && Input.inputString != "9") {
            Debug.Log(Input.inputString);
            heldKeys.Add(Input.inputString);
            CheckKeys();
        } 
        else if (Input.inputString.Length == 2) {
            Debug.Log(Input.inputString);
            if (heldKeys.Contains(Input.inputString[1].ToString())) { 
                heldKeys.Add(Input.inputString[0].ToString());
            }
            else if (heldKeys.Contains(Input.inputString[0].ToString())) {
                heldKeys.Add(Input.inputString[1].ToString());
            }
            CheckKeys();
        }
                    
        for (int i = 0; i < heldKeys.Count; i++) {
            if (Input.GetKeyUp(heldKeys[i])) {
                int index = neededKeys.IndexOf(heldKeys[i]);
                heldKeys.Remove(heldKeys[i]);
                try { 
                    SpriteRenderer sr = keys[index].GetComponent<SpriteRenderer>();
                    sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[index], typeof(Sprite)) as Sprite;
                }
                catch(Exception e) {
                    Debug.Log("Index out of range");
                }
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
                sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[index] + "_press", typeof(Sprite)) as Sprite;
                }
        }

        if (correctButtons == neededKeys.Count) {
            StartCoroutine("DoMopping");
        }
        correctButtons = 0;
    }

    IEnumerator DoMopping() {
        anim.SetBool("isMopping", true);
        goo.level -= 0.2f;
        heldKeys.Clear();
        GenerateKeys();
        aud.Play();

        yield return new WaitForSeconds(1);
        aud.Stop();
        anim.SetBool("isMopping", false);
    }

    void GenerateKeys() {
        neededKeys.Clear();

        //OLD CODE
        //REMOVE WHEN ABBREVIATIONS ARE KNOWN
        //generate a few random chars
        int amount;
        if (goo.level >= 1) {
            amount = UnityEngine.Random.Range(4, 6);
        } else if (goo.level >= 2.5) {
            amount = UnityEngine.Random.Range(5, 8);
        } else {
            amount = UnityEngine.Random.Range(3, 5);
        }
        for (int i = 0; i < amount; i++) {
            char c = (char)('a' + UnityEngine.Random.Range (0,26));

            //avoid double chars
            bool included = false;
            foreach(string s in neededKeys) {
                
                if (c.ToString() == s) {
                   included = true;
                }
            }

            if (!included) {
                neededKeys.Add(c.ToString());
            }
        }

        /* NEW CODE
         * CANNOT USE UNTIL THE ABBREVIATIONS ARE KNOWN
        int word;
        if (goo.level >= 1) {
            word = UnityEngine.Random.Range(11, 20);
        }
        else if (goo.level >= 2.5) {
            word = UnityEngine.Random.Range(21, 30);
        }
        else {
            //default, therefore lowest
            word = UnityEngine.Random.Range(1, 10);
        }

        switch(word) {
            case 1:
                neededKeys.Add("v");
                neededKeys.Add("g");
                neededKeys.Add("n");
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                break;
            case 19:
                break;
            case 20:
                break;
            case 21:
                break;
            case 22:
                break;
            case 23:
                break;
            case 24:
                break;
            case 25:
                break;
            case 26:
                break;
            case 27:
                break;
            case 28:
                break;
            case 29:
                break;
            case 30:
                break;

        }*/

        for (int i = 0; i < keys.Count; i++) {
            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            sr.sprite = null;
        }

        for (int i = 0; i < neededKeys.Count; i++) {

            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[i], typeof(Sprite)) as Sprite;

            keys[i].name = neededKeys[i];
        }
    }
    
}
