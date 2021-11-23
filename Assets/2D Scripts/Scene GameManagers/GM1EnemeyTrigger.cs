using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM1EnemeyTrigger : MonoBehaviour
{
    public GameObject enemy;

    private void Start()
    {
        enemy.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.SetActive(true);
        }
    }
}
