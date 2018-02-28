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
                    
        for (int i = 0; i < heldKeys.Count; i++) {
            if (Input.GetKeyUp(heldKeys[i])) {
                int index = neededKeys.IndexOf(heldKeys[i]);
                heldKeys.Remove(heldKeys[i]);
                try { 
                    SpriteRenderer sr = keys[index].GetComponent<SpriteRenderer>();
                    switch (currentCol) {
                        case 1:
                            sr.sprite = Resources.Load("Keys/Green/" + neededKeys[index] + "_g", typeof(Sprite)) as Sprite;
                            break;
                        case 2:
                            sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[index], typeof(Sprite)) as Sprite;
                            break;
                        case 3:
                            sr.sprite = Resources.Load("Keys/Red/" + neededKeys[index] + "_r", typeof(Sprite)) as Sprite;
                            break;
                        case 4:
                            sr.sprite = Resources.Load("Keys/Yellow/" + neededKeys[index] + "_y", typeof(Sprite)) as Sprite;
                            break;
                        default:
                            sr.sprite = Resources.Load("Keys/Blue/" + neededKeys[index], typeof(Sprite)) as Sprite;
                            break;
                    }
                }
                catch(Exception e) {
                    Debug.Log("Index out of range; button amount messed up");
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
        Debug.Log(faucetManager.faucets[currentCol - 1].gameObject.name);
        if (faucetManager.faucets[currentCol-1].openAmount > 0) {
            faucetManager.faucets[currentCol-1].CloseFaucet();
        }
        heldKeys.Clear();
        GenerateKeys();
        aud.Play();

        yield return new WaitForSeconds(1);
        aud.Stop();
        anim.SetBool("isMopping", false);
    }

    void GenerateKeys() {
        neededKeys.Clear();

        /*OLD CODE
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
        }*/

        //NEW CODE
        int word;
        if (goo.level >= 1) {
            word = UnityEngine.Random.Range(18, 26);
        }
        else if (goo.level >= 2.5) {
            word = UnityEngine.Random.Range(9, 18);
        }
        else {
            //default, therefore lowest
            word = UnityEngine.Random.Range(1, 9);
        }

        switch(word) {
            case 1:
                neededKeys.Add("v");
                neededKeys.Add("g");
                neededKeys.Add("n");
                break;
            case 2:
                neededKeys.Add("g");
                neededKeys.Add("r");
                neededKeys.Add("e");
                neededKeys.Add("n");
                break;
            case 3:
                neededKeys.Add("t");
                neededKeys.Add("r");
                neededKeys.Add("n");
                neededKeys.Add("s");
                break;
            case 4:
                neededKeys.Add("b");
                neededKeys.Add("i");
                neededKeys.Add("c");
                neededKeys.Add("l");
                break;
            case 5:
                neededKeys.Add("l");
                neededKeys.Add("k");
                neededKeys.Add("u");
                neededKeys.Add("p");
                break;
            case 6:
                neededKeys.Add("g");
                neededKeys.Add("a");
                neededKeys.Add("r");
                neededKeys.Add("d");
                neededKeys.Add("n");
                break;
            case 7:
                neededKeys.Add("a");
                neededKeys.Add("c");
                neededKeys.Add("d");
                neededKeys.Add("r");
                neededKeys.Add("n");
                break;
            case 8:
                neededKeys.Add("z");
                neededKeys.Add("r");
                neededKeys.Add("w");
                neededKeys.Add("s");
                neededKeys.Add("t");
                break;
            case 9:
                neededKeys.Add("r");
                neededKeys.Add("c");
                neededKeys.Add("y");
                neededKeys.Add("l");
                break;
            case 10:
                neededKeys.Add("s");
                neededKeys.Add("c");
                neededKeys.Add("r");
                neededKeys.Add("k");
                neededKeys.Add("n");
                neededKeys.Add("g");
                break;
            case 11:
                neededKeys.Add("w");
                neededKeys.Add("t");
                neededKeys.Add("r");
                neededKeys.Add("f");
                neededKeys.Add("u");
                neededKeys.Add("l");
                break;
            case 12:
                neededKeys.Add("a");
                neededKeys.Add("s");
                neededKeys.Add("c");
                neededKeys.Add("n");
                neededKeys.Add("d");
                break;
            case 13:
                neededKeys.Add("c");
                neededKeys.Add("m");
                neededKeys.Add("p");
                neededKeys.Add("s");
                neededKeys.Add("t");
                neededKeys.Add("n");
                neededKeys.Add("p");
                break;
            case 14:
                neededKeys.Add("s");
                neededKeys.Add("u");
                neededKeys.Add("n");
                neededKeys.Add("r");
                neededKeys.Add("g");
                break;
            case 15:
                neededKeys.Add("r");
                neededKeys.Add("e");
                neededKeys.Add("u");
                neededKeys.Add("s");
                break;
            case 16:
                neededKeys.Add("o");
                neededKeys.Add("t");
                neededKeys.Add("h");
                neededKeys.Add("r");
                neededKeys.Add("u");
                neededKeys.Add("s");
                neededKeys.Add("e");
                break;
            case 17:
                neededKeys.Add("q");
                neededKeys.Add("t");
                neededKeys.Add("s");
                neededKeys.Add("m");
                neededKeys.Add("o");
                neededKeys.Add("k");
                neededKeys.Add("n");
                break;
            case 18:
                neededKeys.Add("c");
                neededKeys.Add("r");
                neededKeys.Add("p");
                neededKeys.Add("o");
                neededKeys.Add("l");
                neededKeys.Add("n");
                neededKeys.Add("g");
                break;
            case 19:
                neededKeys.Add("d");
                neededKeys.Add("g");
                neededKeys.Add("r");
                neededKeys.Add("w");
                neededKeys.Add("s");
                neededKeys.Add("t");
                neededKeys.Add("e");
                break;
            case 20:
                neededKeys.Add("s");
                neededKeys.Add("l");
                neededKeys.Add("n");
                neededKeys.Add("r");
                neededKeys.Add("g");
                break;
            case 21:
                neededKeys.Add("v");
                neededKeys.Add("t");
                neededKeys.Add("b");
                neededKeys.Add("l");
                neededKeys.Add("g");
                neededKeys.Add("d");
                neededKeys.Add("n");
                break;
            case 22:
                neededKeys.Add("o");
                neededKeys.Add("t");
                neededKeys.Add("h");
                neededKeys.Add("r");
                neededKeys.Add("u");
                neededKeys.Add("s");
                neededKeys.Add("e");
                break;
            case 23:
                neededKeys.Add("p");
                neededKeys.Add("r");
                neededKeys.Add("d");
                neededKeys.Add("c");
                neededKeys.Add("t");
                neededKeys.Add("l");
                neededKeys.Add("i");
                neededKeys.Add("f");
                break;
            case 24:
                neededKeys.Add("t");
                neededKeys.Add("h");
                neededKeys.Add("n");
                neededKeys.Add("k");
                neededKeys.Add("d");
                neededKeys.Add("f");
                neededKeys.Add("r");
                break;
            case 25:
                neededKeys.Add("p");
                neededKeys.Add("r");
                neededKeys.Add("t");
                neededKeys.Add("c");
                neededKeys.Add("a");
                neededKeys.Add("n");
                neededKeys.Add("m");
                neededKeys.Add("l");
                break;
            default:
                neededKeys.Add("h");
                neededKeys.Add("l");
                neededKeys.Add("t");
                neededKeys.Add("y");
                break;
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
