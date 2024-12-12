using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RightController : MonoBehaviour {
    Light color;
    public bool hit;

    // Start is called before the first frame update
    void Start() {
        color = GetComponent<Light>();
        hit = false;
    }

    // Update is called once per frame
    void Update() {
        if(hit) {
            color.color = Color.red;
        }
        else {
            color.color = Color.green;
        }
    }
}
