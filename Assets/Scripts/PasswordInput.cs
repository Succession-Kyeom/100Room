using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public InputField passwordField; // InputField 연결
    public Button submitButton; // Button 연결
    public DoorController doorController; // 문 제어 스크립트 연결

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        string enteredPassword = passwordField.text; // 입력된 암호
        doorController.TryOpenDoor(enteredPassword); // 문 열기 시도
    }
}
