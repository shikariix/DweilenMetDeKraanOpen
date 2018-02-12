using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour {

    private Vector3 tempPos;
    public SceneController scene;
    
    public float level;

    void Update() {
        tempPos = transform.position;
        tempPos.y = level / 3;
        transform.position = tempPos;

        if (level < -1) {
            level = -1;
        }

        if (level > 3.5f) {
            Debug.Log("You died");
            scene.GameOver();
        }
    }
}
