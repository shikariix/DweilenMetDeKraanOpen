using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour {

    private Vector3 tempPos;
    public SceneController scene;
    private Vector3 mop = new Vector3 (0, 0.1f, 0);
    
    public float level;

    void FixedUpdate() {
        tempPos = Vector3.zero;
        tempPos.y = level;
        transform.position += (tempPos.normalized / 1000);

        if (transform.position.y < -3.7f) {
            transform.position = new Vector3(0, -3.7f, -2);
        }

        if (level > 100) {
            Debug.Log("You died");
            scene.GameOver();
        }
    }

    public void Mop() {
        transform.position -= mop;
        level = level * 0.95f;
    }
}
