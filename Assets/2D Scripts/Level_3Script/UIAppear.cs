using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    public Image coustomImg;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coustomImg.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coustomImg.enabled = false;
        }
    }
}
