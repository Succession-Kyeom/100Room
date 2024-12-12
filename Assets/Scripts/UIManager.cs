using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiCanvas; // UI Canvas
    public GameObject player;  // 플레이어 오브젝트
    private bool isUIActive = false; // UI 활성 상태
    private bool isNearDoor = false; // 문 근처인지 여부

    void Start()
    {
        // 시작할 때 UI 활성화 (필요시 주석 처리 가능)
        ActivateUI();
    }

    void Update()
    {
        // ESC 키로 UI 비활성화
        if (Input.GetKeyDown(KeyCode.Escape) && isUIActive)
        {
            DeactivateUI();
        }

        // 문 근처에서 E 키로 UI 활성화
        if (Input.GetKeyDown(KeyCode.E) && isNearDoor && !isUIActive)
        {
            ActivateUI();
        }
    }

    public void ActivateUI()
    {
        isUIActive = true;
        uiCanvas.SetActive(true); // UI 활성화
        Cursor.lockState = CursorLockMode.None; // 커서 잠금 해제
        Cursor.visible = true; // 커서 보이기
        // 플레이어 움직임 비활성화
        player.GetComponent<PlayerMove>().enabled = false;
    }

    public void DeactivateUI()
    {
        isUIActive = false;
        uiCanvas.SetActive(false); // UI 비활성화
        Cursor.lockState = CursorLockMode.Locked; // 커서 잠금
        Cursor.visible = false; // 커서 숨기기
        // 플레이어 움직임 활성화
        player.GetComponent<PlayerMove>().enabled = true;
    }

    public void SetNearDoor(bool state)
    {
        isNearDoor = state; // 문 근처 상태 업데이트
    }
}
