using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject keyRoomPrefab;

    public int max_keyroom; //소리나는 방 개수

    public int clearCount; //클리어 횟수

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
                continue; //이미 설정된 방이면 다시

            roomNumber.Add(number);
            Debug.Log("Room " + number);

            GameObject roomObject = GameObject.Find("Room " + number);
            GameObject keyRoomBox = Instantiate(keyRoomPrefab, roomObject.transform);
            //Room 객체의 자식으로 Trigger가 될 박스 넣어줌
        }
    }

    public void AddClearCount()
    {
        clearCount++;

        if(clearCount >= max_keyroom)
        {
            Debug.Log("현재 스테이지 클리어. 다음으로 넘어갑니다");
            //다음씬으로
        }
    }
}
