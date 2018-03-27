using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private float time;
    private bool hasKey = false;
    private SpriteRenderer sr;

    public GameObject key;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 2) {
            //give key, display on screen
            key.SetActive(true);
            hasKey = true;
        }
	}

    void OnMouseDown() {
        if (hasKey) {
            sr.sprite = Resources.Load("Door/DeurOpen", typeof(Sprite)) as Sprite;
            transform.position -= new Vector3(0.5f, 0, 0);
            Debug.Log("Door opened");
            hasKey = false;
        } else {
            Debug.Log("Door is Locked");
        }
    }
}
