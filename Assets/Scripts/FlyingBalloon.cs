using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBalloon : MonoBehaviour
{
    public float targetPosition = 200f;
    public float speed = 0.01f;
    public bool flying = false;

    void Update()
    {
        Vector3 target;

        if(flying)
        {
            target = new Vector3(transform.position.x, targetPosition, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, target, speed*Time.deltaTime);
        }
    }

    public void ChangeBalloonState()
    {
        flying = !flying;
    }
}
