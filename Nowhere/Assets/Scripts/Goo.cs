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
        tempPos.y = (level / 20000);
        Debug.Log(level);
        transform.position += tempPos;

        if (level < 4.2f) {
            level = 4.2f;
        }

        if (level > 70) {
            Debug.Log("You died");
            scene.GameOver();
        }
    }

    public void Mop() {
        transform.position -= mop;
        level -= 1;
    }
}
