using UnityEngine;
using System.Collections;

public class Tp : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] CharacterController characterController; // Character Controller ����
    private bool canTeleport = true; // �ڷ���Ʈ ���� ���θ� ��Ÿ���� ����

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport) // �ڷ���Ʈ�� ������ ���� ����
        {
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTeleport = true; // �ڷ����Ϳ��� ����� �ڷ���Ʈ �����ϵ��� ����
    }

    IEnumerator Teleport()
    {
        canTeleport = false; // �ڷ���Ʈ �߿��� �ٽ� �ڷ���Ʈ�� �߻����� �ʵ��� ����
        yield return new WaitForSeconds(0);
        characterController.enabled = false; // �̵� �� ��Ȱ��ȭ

        // ������ x, y, z ������ y�� ��ǥ ��ġ�� ����
        Vector3 targetPosition = tp.position;
        targetPosition.y = characterController.transform.position.y; // ������ y ���� ����
        characterController.transform.position = targetPosition; // ��ġ �̵�

        characterController.enabled = true; // �̵� �� �ٽ� Ȱ��ȭ
    }

}
