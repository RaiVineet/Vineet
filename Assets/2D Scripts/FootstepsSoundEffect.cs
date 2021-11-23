using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSoundEffect : MonoBehaviour
{
    public AudioSource footsteps;
    public bool footstepBool;

    private void Start()
    {
        footsteps = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect()
    {
        footsteps.volume = Random.Range(0.12f, 0.2f);
        footsteps.pitch = Random.Range(0.6f, 0.8f);
        footsteps.Play();
    }
}
