using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM15 : MonoBehaviour
{
    public GameObject AccessDoor17;

    public GameObject doorSFXobj;
    public AudioSource doorUnlockSFX;

    void Start()
    {
        AccessDoor17.SetActive(false);
        doorUnlockSFX = doorSFXobj.GetComponent<AudioSource>();
    }

    public void AccessDoorOn()
    {
        AccessDoor17.SetActive(true);
    }

    public void DoorSFXon()
    {
        doorUnlockSFX.Play();
    }
}
