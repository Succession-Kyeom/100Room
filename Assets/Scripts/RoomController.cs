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
        Debug.Log("KeyRoom ����");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance > maxDistance)
        {
            sound.volume = 0.01f; // �ִ� �Ÿ� �̻��� �� �ּ� ����
        }
        else if (distance < minDistance)
        {
            sound.volume = 1f; // �ּ� �Ÿ� �̳��� �� �ִ� ����
        }
        else
        {
            // �Ÿ��� ����Ͽ� ���� ����
            float volume = 1f - Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
            sound.volume = Mathf.Lerp(0.01f, 1f, volume);
        }

        Debug.Log("��������: " + sound.volume);
    }

    public void CheckTheRoom()
    {

        GameManager.Instance.AddClearCount(); //���� �Ŵ������� �� �ϳ� �Ϸ����� �˸���

        Destroy(gameObject); //��ü �ڽ��� ����
    }
}
