using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public Transform container;
    private float input;
    private Vector3 temp;
    Vector3 mousePos;
    float add;
    float time;

    void Update () {
        /* SCROLL CODE; OLD
        input = Input.GetAxis("Mouse ScrollWheel");
        if (input > 0 && cam.position.y < 10.5f) {
            temp.y = input;
            cam.position += temp;
            
        }*/
        time += Time.deltaTime;
        if (time > 15) { 
            mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            temp = container.position;

            if (mousePos.y > 0.9 || mousePos.x > 0.9 || mousePos.x < 0.2) {
                temp.x = Mathf.Lerp(container.position.x, mousePos.x, 0.001f);
                temp.y = Mathf.Lerp(container.position.y, mousePos.y, 0.001f);
            
                if (mousePos.y > 1) {
                    temp.y += 0.01f;
                }
                container.position = temp;
            }
        }
    }
}
