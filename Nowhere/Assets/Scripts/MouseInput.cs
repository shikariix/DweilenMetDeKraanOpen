using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public Transform cam;
    private float input;
    private Vector3 temp;
    Vector3 mousePos;
    float add;
    float time;

    void Update () {
        /* SCROLL CODE; OLD
        input = Input.GetAxis("Mouse ScrollWheel");
        if (input > 0 && cam.position.y < 2.9f) {
            temp.y = input;
            cam.position += temp;
        }*/
        time += Time.deltaTime;
        if (time > 20) { 
            mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (mousePos.y > 0.9 || mousePos.y < 0.2 || mousePos.x > 0.9 || mousePos.x < 0.2) {
                temp.x = Mathf.Lerp(cam.position.x, mousePos.x, 0.005f);
                temp.y = Mathf.Lerp(cam.position.y, mousePos.y, 0.005f);
            
                if (mousePos.y > 1) {
                    temp.y += 0.01f;
                }
                cam.position = temp;
            }
        }
    }
}
