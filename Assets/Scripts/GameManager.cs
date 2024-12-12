using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject keyRoomPrefab;

    public int max_keyroom; //�Ҹ����� �� ����

    public int clearCount; //Ŭ���� Ƚ��

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetKeyRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetKeyRoom()
    {
        List<int> roomNumber = new List<int>();

        while (roomNumber.Count < max_keyroom)
        {
            int number = Random.Range(1, 26);

            if (roomNumber.Contains(number))
                continue; //�̹� ������ ���̸� �ٽ�

            roomNumber.Add(number);
            Debug.Log("Room " + number);

            GameObject roomObject = GameObject.Find("Room " + number);
            GameObject keyRoomBox = Instantiate(keyRoomPrefab, roomObject.transform);
            //Room ��ü�� �ڽ����� Trigger�� �� �ڽ� �־���
        }
    }

    public void AddClearCount()
    {
        clearCount++;

        if(clearCount >= max_keyroom)
        {
            Debug.Log("���� �������� Ŭ����. �������� �Ѿ�ϴ�");
            //����������
        }
    }
}
