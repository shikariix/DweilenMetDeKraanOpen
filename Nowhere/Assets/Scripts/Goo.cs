using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour {

    private Vector3 tempPos;
    public SceneController scene;
    
    public float level;

    void FixedUpdate() {
            tempPos = transform.position;
            tempPos.y = (level / 40) + 4.2f;
            transform.position = tempPos;

            if (level < 4.2f) {
                level = 4.2f;
            }

            if (level > 70) {
                Debug.Log("You died");
                scene.GameOver();
            }
    }
}
