using UnityEngine;
using UnityEngine.SceneManagement; // Scene 전환에 필요

public class SceneTransition : MonoBehaviour
{
    public string NextScene; // 전환할 Scene 이름

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 Trigger에 들어왔는지 확인
        {
            SceneManager.LoadScene(NextScene); // Scene 전환
        }
    }
}
