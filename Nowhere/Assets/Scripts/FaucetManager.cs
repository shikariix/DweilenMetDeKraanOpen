using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetManager : MonoBehaviour {
    //Manages open faucets and the size of the stream coming out

    public List<Faucet> openFaucets;
    public Faucet[] faucets;

    void Awake() {
        faucets = FindObjectsOfType<Faucet>();
        foreach (Faucet obj in faucets) {
            if (obj.isOpen) {
                openFaucets.Add(obj);
            }
        }
    }

    void Update() {
        //if a faucet is open, it also slightly opens the next
        for (int i = 0; i < faucets.Length; i++) {
            if (faucets[i].isOpen && i < faucets.Length-1) {
                faucets[i + 1].openAmount += 0.001f;
            } else if (faucets[i].isOpen && i == faucets.Length-1) {
                faucets[0].openAmount += 0.001f;
            }
        }
        
    }


    public void UpdateFaucets() {
        openFaucets.Clear();
        foreach (Faucet obj in faucets) {
            if (obj.isOpen) {
                openFaucets.Add(obj);
            }
        }
    }

}
