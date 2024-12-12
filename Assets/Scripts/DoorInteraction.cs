using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public UIManager uiManager; // UIManager ��ũ��Ʈ ����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ������ ������
        {
            uiManager.SetNearDoor(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ ������ �����
        {
            uiManager.SetNearDoor(false);
        }
    }
}
