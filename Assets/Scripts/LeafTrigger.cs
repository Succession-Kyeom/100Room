using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTrigger : MonoBehaviour
{
    AudioSource sound;
    FlyingBalloon flyingBalloon;

    public void Awake()
    {
        sound = gameObject.GetComponent<AudioSource>();
        flyingBalloon = gameObject.GetComponentInChildren<FlyingBalloon>();
    }

    void OnTriggerEnter(Collider other)
    {
        sound.Play();

        if(!flyingBalloon.flying)
            flyingBalloon.ChangeBalloonState();
    }

    void OnTriggerExit(Collider other)
    {
        //sound.Stop();
    }
}
