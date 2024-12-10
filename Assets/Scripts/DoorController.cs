using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string correctPassword = "1234"; // 정답 암호
    public float rotationSpeed = 100f; // 문 회전 속도
    public float openAngle = 90f; // 문이 열리는 각도

    public AudioSource doorSound; // 문이 열릴 때 소리
    public AudioSource wrongPasswordSound; // 암호가 틀렸을 때 소리

    private bool isOpening = false; // 문이 열리는 중인지 여부
    private float currentAngle = 0f; // 현재 회전된 각도

    public void TryOpenDoor(string inputPassword)
    {
        if (inputPassword == correctPassword)
        {
            Debug.Log("Correct password! Opening the door.");
            if (!isOpening) // 중복 재생 방지
            {
                doorSound.Play(); // 소리 재생 (문이 열릴 때)
            }
            isOpening = true; // 문 열림 시작
        }
        else
        {
            Debug.Log("Incorrect password.");
            wrongPasswordSound.Play(); // 틀린 암호 소리 재생
        }
    }

    void Update()
    {
        if (isOpening && currentAngle < openAngle)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            float rotate = Mathf.Min(rotationStep, openAngle - currentAngle);
            transform.Rotate(Vector3.up, rotate); // Y축 기준 회전
            currentAngle += rotate;
        }
    }
}
