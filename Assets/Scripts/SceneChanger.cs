using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Invoke("Change", 0.5f); //0.5초 뒤
    }

    void Change()
    {
        SceneManager.LoadScene("GameScene");
    }
}
