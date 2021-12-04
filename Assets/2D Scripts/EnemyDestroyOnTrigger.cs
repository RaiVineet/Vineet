using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyOnTrigger : MonoBehaviour
{
    public GameObject enemy; // enemy 

   
    // if the gameobject tag named enemy get in the contact of the boxcollider than destroy hat object 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.SetActive(false);
        }
    }



}
