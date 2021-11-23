using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGM : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject openDoor2;

    public AudioSource door1SFX;
    public AudioSource door2SFX;

    void Start()
    {
        openDoor.SetActive(false);
        openDoor2.SetActive(false);

        door1SFX = openDoor.GetComponent<AudioSource>();
        door2SFX = openDoor2.GetComponent<AudioSource>();
    }

    public void Door1()
    {
        openDoor.SetActive(true);
        door1SFX.Play();
    }
    public void Door2()
    {
        openDoor2.SetActive(true);
        door2SFX.Play();
    }
}
