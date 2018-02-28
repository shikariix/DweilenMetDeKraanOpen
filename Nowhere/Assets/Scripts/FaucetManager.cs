using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetManager : MonoBehaviour {
    //Manages open faucets and the size of the stream coming out

    public List<Faucet> openFaucets;
    public Faucet[] faucets;

    public void UpdateFaucets() {
        openFaucets.Clear();
        foreach (Faucet obj in faucets) {
            if (obj.isOpen) {
                openFaucets.Add(obj);
            }
        }
    }

}
