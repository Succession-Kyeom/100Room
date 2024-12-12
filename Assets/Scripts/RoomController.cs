using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public AudioSource sound;

    public Transform playerTransform;

    public float maxDistance = 500f;
    public float minDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        Debug.Log("KeyRoom 생성");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance > maxDistance)
        {
            sound.volume = 0.01f; // 최대 거리 이상일 때 최소 음량
        }
        else if (distance < minDistance)
        {
            sound.volume = 1f; // 최소 거리 이내일 때 최대 음량
        }
        else
        {
            // 거리에 비례하여 음량 감소
            float volume = 1f - Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
            sound.volume = Mathf.Lerp(0.01f, 1f, volume);
        }

        Debug.Log("현재음량: " + sound.volume);
    }

    public void CheckTheRoom()
    {

        GameManager.Instance.AddClearCount(); //게임 매니저에게 방 하나 완료했음 알리고

        Destroy(gameObject); //객체 자신을 삭제
    }
}
