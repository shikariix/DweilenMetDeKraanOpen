using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFaucet : MonoBehaviour {


    public List<string> neededNums;

    public List<Faucet> openFaucets = new List<Faucet>();
    GameObject[] faucetobjs;

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
