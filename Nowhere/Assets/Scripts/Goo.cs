using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour {

    public float level;

    private Vector3 tempPos;
    
    void Update() {
        tempPos = transform.position;
        tempPos.y = level;
        transform.position = tempPos;
    }
}
