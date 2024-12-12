using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!GetComponent<DoorOpen>().open)
            transform.GetComponent<DoorOpen>().ChangeDoorState();
    }

    private void OnTriggerExit(Collider other)
    {
        //transform.GetComponent<DoorOpen>().ChangeDoorState();
    }

}
