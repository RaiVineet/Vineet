using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM3 : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;
    public GameObject AcessDoor;
    public GameObject AccessDoor2;
    public GameObject AccessDoor3;
    public GameObject AccessDoor4;
    public GameObject AccessDoor5;
    public GameObject AccessDoor6;



    public GameObject EnterCollider;
    
    
    

    public GameObject combLock_1;  // room 1 lock
    public GameObject Cabneit_1;   // room 1 cabinet lock

    public GameObject CombLock_2;  // Room2 Lock
    public GameObject Cabneit_2;  // Room 2 Cabinet

    public GameObject combLock_3;  // room 1 lock
    public GameObject Cabneit_3;   // room 1 cabinet lock

    

    public PuzzleUI PUI;
    public GameObject stackofpaper;
    public GameObject stackofFiles;
    

    void Start()
    {




        EnterCollider.GetComponent<BoxCollider>().enabled = false;  // first disable it 
        CombLock_2.SetActive(false);
        combLock_3.SetActive(false);
       // stackofpaper.SetActive(false);
        //stackofFiles.SetActive(false);
        AcessDoor.SetActive(false);
        AccessDoor2.SetActive(false);
        AccessDoor3.SetActive(false);
        AccessDoor4.SetActive(false);
        AccessDoor5.SetActive(false);
        AccessDoor6.SetActive(false);

        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }

        //if (pc.haveFlashlight)
        //{
        //    Destroy(flashlightPickup);        //you can add any items you want as 'backup' pickups in case the player missed them in a previous level. 
        //}                                   

        StartCoroutine(Checkpoint());
    }
    /*
    public void door1()
    {
        Door1.SetActive(true);
        Door1sound.Play();
    }
    */
    IEnumerator Checkpoint()
    {
        yield return new WaitForSeconds(1);
        pc.SavePlayer();
        pc.FindOnScene();
    }

    // opne lock of the cabinet 1 
    public void UnlockCombi1()
    {
        combLock_1.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_1.GetComponent<BoxCollider>().enabled = false;
    }
    public void UnlockComb_2()
    {
        CombLock_2.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_2.GetComponent<BoxCollider>().enabled = false;
    }
    public void UnlockComb_3()
    {
        combLock_3.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_3.GetComponent<BoxCollider>().enabled = false;
    }

    public void AcessDoorOn2()
   {

        AcessDoor.SetActive(true);

   }
    
    
   
}
