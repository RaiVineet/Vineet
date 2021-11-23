using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Door : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;

    void Start()
    {
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pc.LoadLevel2();
        }
    }
}
