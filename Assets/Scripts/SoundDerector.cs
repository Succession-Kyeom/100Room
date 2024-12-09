using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDerector : MonoBehaviour
{
    AudioSource sound;
    bool playing = false;

    public void Awake()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!playing)
        {
            sound.Play();
            playing = !playing;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //sound.Stop();
    }
}
