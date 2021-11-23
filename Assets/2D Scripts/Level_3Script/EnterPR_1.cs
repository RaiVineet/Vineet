using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPR_1 : MonoBehaviour
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

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            pc.LoadPR_1();
            
        }
    }
    
}
