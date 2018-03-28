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
    public Animator streamAnim;

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

        if (isOpen && openAmount < 0.8f) {
            openAmount += 0.0005f;
        }
        
        //Stream animation should be based on openAmount
        if (openAmount < 0.33f) {
            streamAnim.SetBool("Drip", true);

        } else if (openAmount < 0.66f) {
            streamAnim.SetBool("Drip", false);
            streamAnim.SetBool("Moderate", true);
        } else {
            streamAnim.SetBool("Moderate", false);
            streamAnim.SetBool("Heavy", true);
        }
    }

    private IEnumerator CheckToOpenFaucet()
    {
        if (!gameStarted) { 
            yield return new WaitForSeconds(8);
            gameStarted = true;
        }

        random = Random.Range(0, 1000);
        if (fm.openFaucets.Count < 1) {
            OpenFaucet();
        } else if (random == 7 && !isOpen) {
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
