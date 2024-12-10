using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public UIManager uiManager; // UIManager 스크립트 참조

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 범위에 들어오면
        {
            uiManager.SetNearDoor(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 범위를 벗어나면
        {
            uiManager.SetNearDoor(false);
        }
    }
}
