using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] float runSpeed = 50.0f;
    [SerializeField] float mouseSpeed = 3.0f;
    [SerializeField] AudioClip footstepSound; // �߼Ҹ� ����� Ŭ��
    private float gravity = 9.8f;
    private float mouseX;
    private CharacterController controller;
    private Vector3 move;
    private AudioSource audioSource;

    [SerializeField] float footstepInterval = 0.3f; // �߼Ҹ� ���� (��)
    private float footstepTimer; // Ÿ�̸� ����

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
        audioSource.playOnAwake = false; // ���� �� �ڵ� ��� ����
        move = Vector3.zero;
        footstepTimer = 0f; // Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        // ���콺 ȸ�� ó��
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.localEulerAngles = new Vector3(0, mouseX, 0);

        // �̵� ó��
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        float currentFootstepInterval = Input.GetKey(KeyCode.LeftShift) ? footstepInterval / 2f : footstepInterval; // �޸��� �� ���� ����

        if (controller.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);

            if (move.magnitude > 0)
            {
                footstepTimer += Time.deltaTime; // Ÿ�̸� ����
                if (footstepTimer >= currentFootstepInterval)
                {
                    audioSource.Play(); // �߼Ҹ� ���
                    footstepTimer = 0f; // Ÿ�̸� �ʱ�ȭ
                }
            }
            else
            {
                footstepTimer = 0f; // ���߸� Ÿ�̸� �ʱ�ȭ
            }
        }
        else
        {
            move.y -= gravity * Time.deltaTime;
        }
        controller.Move(move * Time.deltaTime * currentSpeed);

        // �� ����/�ݱ� ó��
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
