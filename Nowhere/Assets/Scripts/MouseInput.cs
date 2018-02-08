using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public Transform cam;
    private float input;
    private Vector3 temp; 
	

	void Update () {
        input = Input.GetAxis("Mouse ScrollWheel");
        if (input > 0 && cam.position.y < 2.9f) {
            temp.y = input;
            cam.position += temp;
        }
	}
}
