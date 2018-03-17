using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour {

    private Vector3 tempPos;
    public SceneController scene;
    
    public float level;

    void FixedUpdate() {
            tempPos = transform.position;
            tempPos.y = level / 40 - 1f;
            transform.position = tempPos;

            if (level < -1) {
                level = -1;
            }

            if (level > 40) {
                Debug.Log("You died");
                scene.GameOver();
            }
    }
}
