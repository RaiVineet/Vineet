using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDontDestroy : MonoBehaviour
{
    private static AudioDontDestroy instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }
}
