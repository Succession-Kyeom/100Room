using UnityEngine;
using System.Collections;

public class Tp : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] CharacterController characterController; // Character Controller 참조
    private bool canTeleport = true; // 텔레포트 가능 여부를 나타내는 변수

    private void OnTriggerEnter(Collider other)
    {
        if (canTeleport) // 텔레포트가 가능할 때만 실행
        {
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTeleport = true; // 텔레포터에서 벗어나면 텔레포트 가능하도록 설정
    }

    IEnumerator Teleport()
    {
        canTeleport = false; // 텔레포트 중에는 다시 텔레포트가 발생하지 않도록 설정
        yield return new WaitForSeconds(0);
        characterController.enabled = false; // 이동 전 비활성화

        // 원래의 x, y, z 값에서 y만 목표 위치로 설정
        Vector3 targetPosition = tp.position;
        targetPosition.y = characterController.transform.position.y; // 기존의 y 값을 유지
        characterController.transform.position = targetPosition; // 위치 이동

        characterController.enabled = true; // 이동 후 다시 활성화
    }

}
