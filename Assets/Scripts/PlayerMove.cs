    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField] float speed = 5f; //속도 계수
    [SerializeField] float mouseSpeed = 1f; //회전 계수
    private float gravity;
    private float jump;
    private float mouseX;
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 move;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        move = Vector3.zero;
        gravity = 9.8f;
        jump = 7f;
    }

    // Update is called once per frame
    void Update() {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        this.transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if(Input.GetKey(KeyCode.LeftShift)) {
            speed = 8f;
        }
        else {
            speed = 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

        if(controller.isGrounded) {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = controller.transform.TransformDirection(move);
            
        }
        else {
            move.y -= gravity * Time.deltaTime;
        }

        controller.Move(move * Time.deltaTime * speed);
    }
}
