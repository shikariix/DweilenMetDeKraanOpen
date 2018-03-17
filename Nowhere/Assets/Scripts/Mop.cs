using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mop : MonoBehaviour {

    public Goo goo;
    public FaucetManager faucetManager;
    public List<string> heldKeys = new List<string>();
    public List<string> neededKeys;
    private int correctButtons;
    public int currentCol;
    public List<GameObject> keys;

    public Animator anim;
    public AudioSource aud;

    private bool displayingKeys = false;
    
    void Start() {
        GenerateKeys();
    }

    void Update() {
        if (faucetManager.openFaucets.Count > 0 && !displayingKeys) {
            DisplayKeys();
        }

        if (Input.inputString.ToLower() != "" && Input.anyKeyDown
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
            heldKeys.Add(Input.inputString.ToLower());
            CheckKeys();
        } 
        else if (Input.inputString.Length == 2) {
            Debug.Log(Input.inputString);
            if (heldKeys.Contains(Input.inputString[1].ToString().ToLower())) { 
                heldKeys.Add(Input.inputString[0].ToString().ToLower());
            }
            else if (heldKeys.Contains(Input.inputString[0].ToString().ToLower())) {
                heldKeys.Add(Input.inputString[1].ToString().ToLower());
            }
            CheckKeys();
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
                switch (currentCol) {
                    case 1:
                        sr.sprite = Resources.Load("Keys/Green/" + neededKeys[index] + "_press_g", typeof(Sprite)) as Sprite;
                        break;
                    case 2:
                        sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[index] + "_press", typeof(Sprite)) as Sprite;
                        break;
                    case 3:
                        sr.sprite = Resources.Load("Keys/Red/" + neededKeys[index] + "_press_r", typeof(Sprite)) as Sprite;
                        break;
                    case 4:
                        sr.sprite = Resources.Load("Keys/Yellow/" + neededKeys[index] + "_press_y", typeof(Sprite)) as Sprite;
                        break;
                    default:
                        sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[index] + "_press", typeof(Sprite)) as Sprite;
                        break;
                }
            }
        }

        if (correctButtons == neededKeys.Count) {
            StartCoroutine("DoMopping");
        }
        correctButtons = 0;
    }

    IEnumerator DoMopping() {
        anim.SetBool("isMopping", true);
        goo.level -= 0.15f;
        heldKeys.Clear();
        GenerateKeys();
        aud.Play();

        yield return new WaitForSeconds(1);
        aud.Stop();
        anim.SetBool("isMopping", false);
    }

    void GenerateKeys() {
        neededKeys.Clear();

        //NEW CODE
        int word;
        if (goo.level >= 7) {
            word = UnityEngine.Random.Range(18, 26);
        }
        else if (goo.level >= 15) {
            word = UnityEngine.Random.Range(9, 18);
        }
        else {
            //default, therefore lowest
            word = UnityEngine.Random.Range(1, 9);
        }
        string letters = "";
        
        switch(word) {
            case 1:
                letters = "vegan";
                break;
            case 2:
                letters = "green";
                break;
            case 3:
                letters = "trains";
                break;
            case 4:
                letters = "bicycle";
                break;
            case 5:
                letters = "lookup";
                break;
            case 6:
                letters = "garden";
                break;
            case 7:
                letters = "healthy";
                break;
            case 8:
                letters = "zerowaste";
                break;
            case 9:
                letters = "recycle";
                break;
            case 10:
                letters = "scrkng";
                break;
            case 11:
                letters = "waterfuel";
                break;
            case 12:
                letters = "ascend";
                break;
            case 13:
                letters = "composting";
                break;
            case 14:
                letters = "sunenergy";
                break;
            case 15:
                letters = "reuse";
                break;
            case 16:
                letters = "otheruses";
                break;
            case 17:
                letters = "quitsmoking";
                break;
            case 18:
                letters = "crpolng";
                break;
            case 19:
                letters = "degradewaste";
                break;
            case 20:
                letters = "solarenergy";
                break;
            case 21:
                letters = "vegetablegarden";
                break;
            case 22:
                letters = "otheruses";
                break;
            case 23:
                letters = "productlife";
                break;
            case 24:
                letters = "thinkdifferent";
                break;
            case 25:
                letters = "protectanimals";
                break;
            default:
                letters = "healthy";
                break;
        }
        
        
        foreach (Char c in letters) {
            neededKeys.Add(c.ToString());
        }
        
        currentCol = UnityEngine.Random.Range(1, 5);
        if (displayingKeys) {
            DisplayKeys();
        }
    }

    void DisplayKeys() {
        displayingKeys = true;
        //empty keys so none are left behind
        for (int i = 0; i < keys.Count; i++) {
            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            sr.sprite = null;
        }

        for (int i = 0; i < neededKeys.Count; i++) {
            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            switch (currentCol) {
                case 1:
                    sr.sprite = Resources.Load("Keys/Green/" + neededKeys[i] + "_g", typeof(Sprite)) as Sprite;
                    break;
                case 2:
                    sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[i], typeof(Sprite)) as Sprite;
                    break;
                case 3:
                    sr.sprite = Resources.Load("Keys/Red/" + neededKeys[i] + "_r", typeof(Sprite)) as Sprite;
                    break;
                case 4:
                    sr.sprite = Resources.Load("Keys/Yellow/" + neededKeys[i] + "_y", typeof(Sprite)) as Sprite;
                    break;
                default:
                    sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[i], typeof(Sprite)) as Sprite;
                    break;
            }

            keys[i].name = neededKeys[i];
        }
    }
    
}
