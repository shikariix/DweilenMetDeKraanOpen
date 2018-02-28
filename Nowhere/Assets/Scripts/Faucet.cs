using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour {
    //manages faucet status, sprite of the faucet, all that jazz

    public Goo goo;
    public FaucetManager fm;
    public bool isOpen = false;
    public SpriteRenderer sr;
    private int random;
    public GameObject stream;

    public float openAmount;


    public AudioSource aud;

    void Update() {
        random = Random.Range(0, 1000);
        if (random == 7 && !isOpen) {
            OpenFaucet();
        }

        if (isOpen) {
            goo.level += openAmount * 0.0003f;
            //sr.sprite = Resources.Load("kraan_glow", typeof(Sprite)) as Sprite;
        } else {
            //sr.sprite = Resources.Load("kraan", typeof(Sprite)) as Sprite;
        }

        if (openAmount > 0) {
            //isOpen = true;
            stream.SetActive(true);
        } else {
            stream.SetActive(false);
        }

        //Stream animation should be based on openAmount

    }

    void OpenFaucet() {
        isOpen = true;
        openAmount = 1;
        fm.UpdateFaucets();
        Debug.Log("Faucet Opened");
        stream.SetActive(true);
        aud.Play();

        //if a faucet is open, it also slightly opens the next
        for (int i = 0; i < fm.faucets.Length; i++) {
            if (fm.faucets[i].isOpen && i < fm.faucets.Length - 1) {
                fm.faucets[i + 1].openAmount += 0.05f;
            }
            else if (fm.faucets[i].isOpen && i == fm.faucets.Length - 1) {
                fm.faucets[0].openAmount += 0.05f;
            }
        }
    }

    public void CloseFaucet() {
        openAmount -= 0.5f;
        Debug.Log(gameObject.name + " open level: " + openAmount);
        if (openAmount <= 0) { 
            isOpen = false;
            Debug.Log("Faucet Closed");
            stream.SetActive(false);
            aud.Stop();
            openAmount = 0;
        }
    }
}
