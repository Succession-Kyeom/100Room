using UnityEngine;
using UnityEngine.SceneManagement; // Scene ��ȯ�� �ʿ�

public class SceneTransition : MonoBehaviour
{
    public string NextScene; // ��ȯ�� Scene �̸�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ Trigger�� ���Դ��� Ȯ��
        {
            SceneManager.LoadScene(NextScene); // Scene ��ȯ
        }
    }
}
