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
    private int previousCol;
    public GameObject[] keys;

    public Animator anim;
    public AudioSource aud;
    public AudioSource wordAud;

    private bool displayingKeys = false;
    private int correctKeys = 0;
    private float time;
    private int word;
    private int previousWord;
    
    void Start() {
        GenerateKeys();
    }

    void Update() {
        time += Time.deltaTime;
        if (faucetManager.openFaucets.Count > 0 && !displayingKeys && time > 20) {
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
            var sr = keys[correctKeys].GetComponent<Image>();
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

            StartCoroutine("MopAnimation");
            correctKeys++;

        }

        if (correctKeys == neededKeys.Count) {
            DoMopping();
            correctKeys = 0;
        }
    }

    void DoMopping() {
        wordAud.Play();
        goo.level -= 1;
        GenerateKeys();
    }

    IEnumerator MopAnimation() {
        anim.SetBool("isMopping", true);
        aud.Play();

        yield return new WaitForSeconds(1);
        anim.SetBool("isMopping", false);
        aud.Stop();
    }

    void GenerateKeys() {
        neededKeys.Clear();
        
        //avoid having the same word twice;
        int num = GenerateNum(previousWord);
        
        word = num;
        
        string letters = "";
        
        switch(word) {
            case 1:
                letters = "vegan";
                break;
            case 2:
                letters = "unplug";
                break;
            case 3:
                letters = "trains";
                break;
            case 4:
                letters = "bicycle";
                break;
            case 5:
                letters = "up";
                break;
            case 6:
                letters = "garden";
                break;
            case 7:
                letters = "reuse";
                break;
            case 8:
                letters = "zerowaste";
                break;
            case 9:
                letters = "recycle";
                break;
            case 10:
                letters = "greenenergy";
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
                letters = "go-up";
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
                letters = "windenergy";
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
            case 31:
                letters = "userainwater";
                break;
            case 32:
                letters = "longproductlife";
                break;
            case 33:
                letters = "waterenergy";
                break;
            case 34:
                letters = "reducegas";
                break;
            case 35:
                letters = "nofossilfuel";
                break;
            case 36:
                letters = "thinkdifferent";
                break;
            case 37:
                letters = "go-up";
                break;
            case 38:
                letters = "opendoor";
                break;
            case 39:
                letters = "findkey";
                break;
            case 40:
                letters = "outoftime";
                break;
            default:
                letters = "thinkdifferent";
                break;
        }
        previousWord = word;
        
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
        //empty keys so no letters are left behind
        for (int i = 0; i < keys.Length; i++) {
            Image sr = keys[i].GetComponent<Image>();
            var alpha = sr.color;
            alpha.a = 0;
            sr.color = alpha;
            Text t = keys[i].GetComponentInChildren<Text>();
            t.text = "";
        }

        for (int i = 0; i < neededKeys.Count; i++) {
            Image sr = keys[i].GetComponent<Image>();
            var alpha = sr.color;
            alpha.a = 1;
            sr.color = alpha;

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
    
    private int GenerateNum(int previous) {
        int num;
        if (time < 20) {
            if (goo.level >= 35) {
                num = UnityEngine.Random.Range(24, 36);
            }
            else if (goo.level >= 17) {
                num = UnityEngine.Random.Range(12, 24);
            }
            else {
                //default, therefore lowest
                num = UnityEngine.Random.Range(1, 12);
            }
        }
        else {
            num = UnityEngine.Random.Range(36, 40);
        }

        if (num == previous) {
            return GenerateNum(num);
        } else {
            return num;
        }
    }
}
