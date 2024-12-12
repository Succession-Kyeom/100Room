using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string correctPassword = "1234"; // ���� ��ȣ
    public float rotationSpeed = 100f; // �� ȸ�� �ӵ�
    public float openAngle = 90f; // ���� ������ ����

    public AudioSource doorSound; // ���� ���� �� �Ҹ�
    public AudioSource wrongPasswordSound; // ��ȣ�� Ʋ���� �� �Ҹ�

    private bool isOpening = false; // ���� ������ ������ ����
    private float currentAngle = 0f; // ���� ȸ���� ����

    public void TryOpenDoor(string inputPassword)
    {
        if (inputPassword == correctPassword)
        {
            Debug.Log("Correct password! Opening the door.");
            if (!isOpening) // �ߺ� ��� ����
            {
                doorSound.Play(); // �Ҹ� ��� (���� ���� ��)
            }
            isOpening = true; // �� ���� ����
        }
        else
        {
            Debug.Log("Incorrect password.");
            wrongPasswordSound.Play(); // Ʋ�� ��ȣ �Ҹ� ���
        }
    }

    void Update()
    {
        if (isOpening && currentAngle < openAngle)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            float rotate = Mathf.Min(rotationStep, openAngle - currentAngle);
            transform.Rotate(Vector3.up, rotate); // Y�� ���� ȸ��
            currentAngle += rotate;
        }
    }
}
