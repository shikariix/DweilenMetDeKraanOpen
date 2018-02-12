using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFaucet : MonoBehaviour {


    public List<string> neededNums;

    public List<Faucet> openFaucets = new List<Faucet>();
    GameObject[] faucetobjs;

    public List<GameObject> nums;

    void Awake() {
        faucetobjs = GameObject.FindGameObjectsWithTag("Faucet");
        foreach (GameObject obj in faucetobjs) {
            Faucet temp = obj.GetComponent<Faucet>();
            if (temp.isOpen) { 
                openFaucets.Add(temp);
            }
        }
        GenerateNumbers();
    }

    void Update() {
        if (neededNums.Contains(Input.inputString)) {
            Debug.Log("Got it!");
            neededNums.Remove(Input.inputString);
        }

        if (neededNums.Count < 1) {
            openFaucets[0].CloseFaucet();
            GenerateNumbers();
        }
        UpdateFaucets();

        if (openFaucets.Count > 0) {
            DisplayNumbers();
        }
    }
    
    void GenerateNumbers() {

        neededNums.Clear();
        //generate a few random nums
        int amount = Random.Range(3, 7);
        for (int i = 0; i < amount; i++) {
            int c = Random.Range (0,10);
            neededNums.Add(c.ToString());
        }
    }

    void DisplayNumbers() {
        /*
        for (int i = 0; i < nums.Count; i++) {
            SpriteRenderer sr = nums[i].GetComponent<SpriteRenderer>();
            sr.sprite = null;
        }

        for (int i = 0; i < neededNums.Count; i++) {

            SpriteRenderer sr = nums[i].GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load("Keys/" + neededNums[i], typeof(Sprite)) as Sprite;

            nums[i].name = neededNums[i];
        }*/
    }

    void UpdateFaucets() {
        openFaucets.Clear();
        foreach (GameObject obj in faucetobjs) {
            Faucet temp = obj.GetComponent<Faucet>();
            if (temp.isOpen) {
                openFaucets.Add(temp);
            }
        }
    }
}
