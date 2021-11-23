using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs2 : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;

    public bool playerIn;
    public GameObject _collider;

    private void Start()
    {
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        playerIn = false;

        _collider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }

    private void Update()
    {
        if (playerIn)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _collider.SetActive(true);
            }
        }
    }
}
