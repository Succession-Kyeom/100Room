using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {
    GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() { 
        if(Vector3.Distance(this.transform.position, player.transform.position) < 0.2f) {
            Application.Quit();
        }
    }
}
