using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Trigger : MonoBehaviour
{
    public AudioClip Sound;
    private bool hasplayed = false;

    void OnTriggerEnter2D()
    {
        if (!hasplayed)
        {
            GetComponent<AudioSource>().PlayOneShot(Sound);
            hasplayed = true;
           
        }

    }


}
