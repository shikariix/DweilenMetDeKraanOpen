using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private float time;
    private bool hasKey = false;
    private SpriteRenderer sr;
    private AudioSource aud;

    public GameObject hanginglock;
    public GameObject key;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 60) {
            //give key, display on screen
            key.SetActive(true);
            hasKey = true;
        }
	}

    void OnMouseDown() {
        if (hasKey && hanginglock.activeSelf) {
            hanginglock.SetActive(false);
            Debug.Log("Door unlocked");
            hasKey = false;
        } else if (hanginglock.activeSelf && !hasKey) {
            Debug.Log("Door is locked");
        } else {
            sr.sprite = Resources.Load("Door/DeurOpen", typeof(Sprite)) as Sprite;
            aud.Play();
            transform.position -= new Vector3(0.9f, 0, 0);
        }
    }
}
