using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {
    bool isActioned;
    Light color;
    
    // Start is called before the first frame update
    void Start() {
        isActioned = false;
        color = GameObject.Find("Key").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update() {
        if(color.color == Color.green) {
            isActioned = true;
        }

        if(isActioned) {
            while(this.transform.position.y > -3.0f) {
                this.transform.position -= new Vector3(0, 0.08f, 0) * Time.deltaTime;
            }
        }
    }
}
