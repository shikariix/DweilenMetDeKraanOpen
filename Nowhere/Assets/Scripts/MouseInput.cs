using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public Transform container;
    private float input;
    private Vector3 temp;
    Vector3 mousePos;
    float add;

    void Update () {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        temp = container.position;

        //Container can't move so far that the void is visible
        if (container.position.y <= 8.1f && container.position.y > 2.6f ) { 
            //If the mouse is at the top, move container down; if the mouse is at the bottom, move container up
            if (mousePos.y > 0.9) {
                 temp.y -= 0.01f;
                container.position = temp;
            } else if (mousePos.y < 0.1) {
                temp.y += 0.01f;
                container.position = temp;
            }
            
        } else if (container.position.y > 8.1f) {
            container.position = new Vector3(container.position.x, 8.1f, container.position.z);
        }
    }
}
