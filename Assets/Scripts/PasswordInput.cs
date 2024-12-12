using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public InputField passwordField; // InputField ����
    public Button submitButton; // Button ����
    public DoorController doorController; // �� ���� ��ũ��Ʈ ����

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        string enteredPassword = passwordField.text; // �Էµ� ��ȣ
        doorController.TryOpenDoor(enteredPassword); // �� ���� �õ�
    }
}
