using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour {

    public Goo goo;
    public bool isOpen = false;
    public SpriteRenderer sr;
    private int random;
    public GameObject stream;


    public AudioSource aud;

    void Update() {
        random = Random.Range(0, 1000);
        if (random == 7 && !isOpen) {
            OpenFaucet();
        }

        if (isOpen) {
            goo.level += 0.0005f;
            sr.sprite = Resources.Load("kraan_glow", typeof(Sprite)) as Sprite;
        } else {
            sr.sprite = Resources.Load("kraan", typeof(Sprite)) as Sprite;
        }
    }

    void OpenFaucet() {
        isOpen = true;
        Debug.Log("Faucet Opened");
        stream.SetActive(true);
        aud.Play();
    }

    public void CloseFaucet() {
        isOpen = false;
        Debug.Log("Faucet Closed");
        stream.SetActive(false);
        aud.Stop();
    }
}
