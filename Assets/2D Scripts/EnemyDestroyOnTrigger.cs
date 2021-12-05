using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyDestroyOnTrigger : MonoBehaviour
{
    public GameObject enemy; // enemy 
    //public Light2D redLight;
    //public Light2D normalLight;

    //private void Start()
    //{

    //    normalLight.gameObject.SetActive(true);
    //}
    //if the gameobject tag named enemy get in the contact of the boxcollider than destroy hat object 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            enemy.SetActive(false);
            //redLight.gameObject.SetActive(false);
            //normalLight.gameObject.SetActive(true);
        }
    }



}
