using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] float runSpeed = 50.0f;
    [SerializeField] float mouseSpeed = 3.0f;
    [SerializeField] AudioClip footstepSound; // 발소리 오디오 클립
    private float gravity = 9.8f;
    private float mouseX;
    private CharacterController controller;
    private Vector3 move;
    private AudioSource audioSource;

    [SerializeField] float footstepInterval = 0.3f; // 발소리 간격 (초)
    private float footstepTimer; // 타이머 변수

    public float interactDistance = 20f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = footstepSound;
        audioSource.playOnAwake = false; // 시작 시 자동 재생 방지
        move = Vector3.zero;
        footstepTimer = 0f; // 타이머 초기화
    }

    void Update()
    {
        // 마우스 회전 처리
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.localEulerAngles = new Vector3(0, mouseX, 0);

        // 이동 처리
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        float currentFootstepInterval = Input.GetKey(KeyCode.LeftShift) ? footstepInterval / 2f : footstepInterval; // 달리기 시 간격 단축

        if (controller.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);

            if (move.magnitude > 0)
            {
                footstepTimer += Time.deltaTime; // 타이머 증가
                if (footstepTimer >= currentFootstepInterval)
                {
                    audioSource.Play(); // 발소리 재생
                    footstepTimer = 0f; // 타이머 초기화
                }
            }
            else
            {
                footstepTimer = 0f; // 멈추면 타이머 초기화
            }
        }
        else
        {
            move.y -= gravity * Time.deltaTime;
        }
        controller.Move(move * Time.deltaTime * currentSpeed);

        // 문 열기/닫기 처리
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider != null && hit.collider.CompareTag("Door"))
                {
                    var doorParent = hit.collider.transform.parent;
                    if (doorParent != null)
                    {
                        var doorMech = doorParent.GetComponent<DoorMech>();
                        if (doorMech != null)
                        {
                            doorMech.ChangeDoorState();
                        }
                    }
                }
            }
        }
    }
}
