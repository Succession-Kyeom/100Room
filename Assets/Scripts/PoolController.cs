using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {
    bool isActioned = false;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(isActioned) {
            while(this.transform.position.y > 0.1) {
                this.transform.position = new Vector3(0, -0.08f, 0) * Time.deltaTime;
            }
        }
    }
}
