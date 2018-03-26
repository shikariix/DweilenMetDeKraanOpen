using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoofdkraan : MonoBehaviour {

    public SceneController scene;

    void OnMouseDown() {
        scene.Win();
    }
}
