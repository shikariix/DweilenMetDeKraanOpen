using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFaucet : MonoBehaviour {


    public List<string> neededNums;

    private List<Faucet> faucets = new List<Faucet>();

    void Awake() {
        GameObject[] faucetobjs = GameObject.FindGameObjectsWithTag("Faucet");
        foreach (GameObject obj in faucetobjs) {
            Faucet temp = obj.GetComponent<Faucet>();
            faucets.Add(temp);
        }
        GenerateNumbers();
    }

    void Update() {
        if (neededNums.Contains(Input.inputString)) {
            Debug.Log("Got it!");
        }
    }
    
    void GenerateNumbers() {

        neededNums.Clear();
        //generate a few random nums
        int amount = Random.Range(3, 7);
        for (int i = 0; i < amount; i++) {
            int c = Random.Range (0,10);
            neededNums.Add(c.ToString());
            Debug.Log(neededNums[i]);
        }
    }

    void CloseThatBinch(Faucet f) {
        f.isOpen = false;
    }
}
