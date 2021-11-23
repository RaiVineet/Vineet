using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderStairs : MonoBehaviour
{    
    public GameObject _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _collider.SetActive(false);
        }
    }
}
