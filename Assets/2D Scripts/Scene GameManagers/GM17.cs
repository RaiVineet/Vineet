using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM17 : MonoBehaviour
{
    public GameObject AccessDoor18;

    void Start()
    {
        AccessDoor18.SetActive(false);
    }

    public void AccessDoorOn()
    {
        AccessDoor18.SetActive(true);
    }
}
