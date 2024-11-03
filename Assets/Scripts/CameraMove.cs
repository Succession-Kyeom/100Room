using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    [SerializeField] private float mouseSpeed = 1f;
    private float mouseY = 0f; //수직 회전값
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            for(int i = 0; i < 10; i++) {
                mouseY += 3f;
            }
            for(int i = 0; i < 10; i++) {
                mouseY -= 3f;
            }
        }

        this.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
