using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour {
    //manages faucet status, sprite of the faucet, all that jazz

    public Goo goo;
    public FaucetManager fm;
    public bool isOpen = false;
    private int random;
    private bool gameStarted = false;
    public GameObject stream;

    public float openAmount;

    public AudioSource aud;
    
    
    void FixedUpdate() {
        StartCoroutine("CheckToOpenFaucet");

        if (isOpen) {
            goo.level += openAmount * Time.deltaTime;
        }
        if (openAmount > 0) {
            stream.SetActive(true);
        }
        else {
            stream.SetActive(false);
        }

        if (isOpen && openAmount < 1) {
            openAmount += 0.0005f;
        }
        
        //Stream animation should be based on openAmount
        Vector3 tempScale = stream.transform.localScale;
        tempScale.x = openAmount;
        stream.transform.localScale = tempScale;
    }

    private IEnumerator CheckToOpenFaucet()
    {
        if (!gameStarted) { 
        yield return new WaitForSeconds(4);
            gameStarted = true;
        }

        random = Random.Range(0, 1000);
        if (random == 7 && !isOpen)
        {
            OpenFaucet();
        }
    }

    void OpenFaucet() {
        isOpen = true;
        fm.UpdateFaucets();
        Debug.Log("Faucet Opened");
        stream.SetActive(true);
        aud.Play();
    }
}
