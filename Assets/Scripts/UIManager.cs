using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiCanvas; // UI Canvas
    public GameObject player;  // �÷��̾� ������Ʈ
    private bool isUIActive = false; // UI Ȱ�� ����
    private bool isNearDoor = false; // �� ��ó���� ����

    void Start()
    {
        // ������ �� UI Ȱ��ȭ (�ʿ�� �ּ� ó�� ����)
        ActivateUI();
    }

    void Update()
    {
        // ESC Ű�� UI ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape) && isUIActive)
        {
            DeactivateUI();
        }

        // �� ��ó���� E Ű�� UI Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.E) && isNearDoor && !isUIActive)
        {
            ActivateUI();
        }
    }

    public void ActivateUI()
    {
        isUIActive = true;
        uiCanvas.SetActive(true); // UI Ȱ��ȭ
        Cursor.lockState = CursorLockMode.None; // Ŀ�� ��� ����
        Cursor.visible = true; // Ŀ�� ���̱�
        // �÷��̾� ������ ��Ȱ��ȭ
        player.GetComponent<PlayerMove>().enabled = false;
    }

    public void DeactivateUI()
    {
        isUIActive = false;
        uiCanvas.SetActive(false); // UI ��Ȱ��ȭ
        Cursor.lockState = CursorLockMode.Locked; // Ŀ�� ���
        Cursor.visible = false; // Ŀ�� �����
        // �÷��̾� ������ Ȱ��ȭ
        player.GetComponent<PlayerMove>().enabled = true;
    }

    public void SetNearDoor(bool state)
    {
        isNearDoor = state; // �� ��ó ���� ������Ʈ
    }
}
