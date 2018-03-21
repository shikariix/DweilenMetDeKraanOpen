using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Mop : MonoBehaviour {

    public Goo goo;
    public FaucetManager faucetManager;
    public List<string> heldKeys = new List<string>();
    public List<string> neededKeys;
    public int currentCol;
    public GameObject[] keys;

    public Animator anim;
    public AudioSource aud;

    private bool displayingKeys = false;
    private int correctKeys = 0;
    
    void Start() {
        GenerateKeys();
    }

    void Update() {
        if (faucetManager.openFaucets.Count > 0 && !displayingKeys) {
            DisplayKeys();
        }
        
        if (Input.inputString != "" || Input.inputString != "0"
                                    || Input.inputString != "1"
                                    || Input.inputString != "2"
                                    || Input.inputString != "3"
                                    || Input.inputString != "4"
                                    || Input.inputString != "5"
                                    || Input.inputString != "6"
                                    || Input.inputString != "7"
                                    || Input.inputString != "8"
                                    || Input.inputString != "9") {
            CheckKeys(Input.inputString);
            
        }
    }
    
    void CheckKeys(string input) {
        
        //check if buttons are equal
        if (neededKeys[correctKeys] == input) {
            //Make sprite glow when it is pressed
            var sr = keys[correctKeys].GetComponent<SpriteRenderer>();
            var t = keys[correctKeys].GetComponentInChildren<Text>();
            switch (currentCol) {
                case 1:
                    sr.sprite = Resources.Load("Keys/g_press", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[correctKeys].ToUpper();
                    break;
                case 2:
                    sr.sprite = Resources.Load("Keys/b_press", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[correctKeys].ToUpper();
                    break;
                case 3:
                    sr.sprite = Resources.Load("Keys/r_press", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[correctKeys].ToUpper();
                    break;
                case 4:
                    sr.sprite = Resources.Load("Keys/y_press", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[correctKeys].ToUpper();
                    break;
                default:
                    sr.sprite = Resources.Load("Keys/b_press", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[correctKeys].ToUpper();
                    break;
            }

            correctKeys++;

        }

        if (correctKeys == neededKeys.Count) {
            StartCoroutine("DoMopping");
            correctKeys = 0;
        }
    }

    IEnumerator DoMopping() {
        anim.SetBool("isMopping", true);
        goo.level -= 1;
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
        if (goo.level >= 25) {
            word = UnityEngine.Random.Range(21, 31);
        }
        else if (goo.level >= 12) {
            word = UnityEngine.Random.Range(11, 21);
        }
        else {
            //default, therefore lowest
            word = UnityEngine.Random.Range(1, 11);
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
                letters = "userainwater";
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
                letters = "opendoor";
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
                letters = "carpooling";
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
                letters = "durablecontainer";
                break;
            case 26:
                letters = "scraprecipes";
                break;
            case 27:
                letters = "papercups";
                break;
            case 28:
                letters = "planttrees";
                break;
            case 29:
                letters = "findkey";
                break;
            case 30:
                letters = "vegandiet";
                break;
            default:
                letters = "thinkdifferent";
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
        for (int i = 0; i < keys.Length; i++) {
            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            sr.sprite = null;
            Text t = keys[i].GetComponentInChildren<Text>();
            t.text = "";
        }

        for (int i = 0; i < neededKeys.Count; i++) {
            SpriteRenderer sr = keys[i].GetComponent<SpriteRenderer>();
            Text t = keys[i].GetComponentInChildren<Text>();
            switch (currentCol) {
                case 1:
                    sr.sprite = Resources.Load("Keys/g", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[i].ToUpper();
                    break;
                case 2:
                    sr.sprite = Resources.Load("Keys/b", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[i].ToUpper();
                    break;
                case 3:
                    sr.sprite = Resources.Load("Keys/r", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[i].ToUpper();
                    break;
                case 4:
                    sr.sprite = Resources.Load("Keys/g", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[i].ToUpper();
                    break;
                default:
                    sr.sprite = Resources.Load("Keys/b", typeof(Sprite)) as Sprite;
                    t.text = neededKeys[i].ToUpper();
                    break;
            }

            keys[i].name = neededKeys[i];
        }
    }
    
}
