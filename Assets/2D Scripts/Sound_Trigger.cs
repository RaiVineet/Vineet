using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Trigger : MonoBehaviour
{
    public AudioClip Sound;
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().PlayOneShot(Sound);

    }


}
