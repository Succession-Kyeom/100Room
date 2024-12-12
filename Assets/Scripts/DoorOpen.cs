using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float openAngle = 180f;
    public float closeAngle = 90f;
    public float speed = 1f;
    public bool open = false;

    Quaternion target;

    void Update()
    {
        if(open)
        {
            target = Quaternion.Euler(0, openAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, speed*Time.deltaTime);
        }

        else if(!open)
        {
            target = Quaternion.Euler(0, closeAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, speed*Time.deltaTime);
        }
        
    }

    public void ChangeDoorState()
    {
        open = !open;
    }
}
