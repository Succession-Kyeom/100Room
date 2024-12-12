using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    GameObject player;
    GameObject angle;
    RightController rightController;
    RaycastHit hit;
    bool get;
    
    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        angle = GameObject.Find("Main Camera");
        get = false;
        rightController = GameObject.Find("Key").GetComponent<RightController>();
    }

    // Update is called once per frame
    void Update() {
        if(Vector3.Distance(this.transform.position, player.transform.position) <= 1) {
            if(Input.GetKey(KeyCode.E)) {
                get = true;
            }
        }
        if(get) {
            this.transform.position -= new Vector3(0, -10, 0);
            if(Input.GetMouseButtonDown(0)) {
                if(Physics.Raycast(angle.transform.position, angle.transform.forward, out hit)) {
                    if(hit.collider.gameObject.name == "KeyLamp") {
                        rightController.hit = true;
                    }
                }
                
            }
        }
    }
}
