using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    private static Camerascript instance;
    public GameObject player;

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
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5.5f, transform.position.z);

        if (transform.position.x < -50)
        {
            transform.position = new Vector3(-50, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 10000)     //make it stick to level borders by defining them
        {
            transform.position = new Vector3(10000, transform.position.y, transform.position.z);
        }
    }
}
