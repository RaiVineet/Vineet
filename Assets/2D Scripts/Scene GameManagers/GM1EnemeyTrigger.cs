using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GM1EnemeyTrigger : MonoBehaviour
{
    public GameObject enemy;
    //public Light2D redLight;
    //public Light2D normalLight;

    private void Start()
    {
        enemy.SetActive(false);
       // redLight.gameObject.SetActive(false); // deactive the red light on enemy trigger 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            enemy.SetActive(true);
            //redLight.gameObject.SetActive(true);    // active the red light on enemy trigger
            //normalLight.gameObject.SetActive(false); // deactivate the noramal light on trigger
        }
    }
}
