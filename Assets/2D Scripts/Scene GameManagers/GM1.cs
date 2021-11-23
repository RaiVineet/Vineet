using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM1 : MonoBehaviour
{
    public GameObject lockedDoor;
    public Canvas Lock1;

    public GameObject flashlightPickup;

    //public GameObject lightbulbStand1;
    //public GameObject lightbulbStand2;
    //public GameObject lightbulbStand3;
    public GameObject AccessDoor;
    public GameObject EndOfLevelDoor;
    public GameObject EndOfLevelDoorOpen;
    public GameObject NextLevel;

    public GameObject globalLight;
    //public GameObject enemy;

    //public GameObject shadow;
    //public Animator shadowanim;

    public GameObject doorSFXobj;
    public AudioSource doorUnlockSFX;

    public GameObject p;
    public PlayerControl pc;

    void Start()
    {
        Lock1.gameObject.SetActive(false);

        //lightbulbStand1.SetActive(false);
        //lightbulbStand2.SetActive(false);
        //lightbulbStand3.SetActive(false);
        AccessDoor.SetActive(false);
        NextLevel.SetActive(false);
        EndOfLevelDoorOpen.SetActive(false);

        //shadowanim = shadow.GetComponent<Animator>();

        globalLight.SetActive(false);
        //enemy.SetActive(false);

        doorUnlockSFX = doorSFXobj.GetComponent<AudioSource>();

        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }

        if (pc.haveFlashlight)
        {
            Destroy(flashlightPickup);
        }

        StartCoroutine(Checkpoint());
    }

    IEnumerator Checkpoint()
    {
        yield return new WaitForSeconds(1);
        pc.SavePlayer();
        pc.FindOnScene();
    }

    public void AccessDoorOn()
    {
        AccessDoor.SetActive(true);
    }

    public void NextLevelDoor()
    {
        NextLevel.SetActive(true);
        EndOfLevelDoor.SetActive(false);
        EndOfLevelDoorOpen.SetActive(true);
    }

    //public void Stand1()
    //{
    //    lightbulbStand1.SetActive(true);
    //}
    //public void Stand2()
    //{
    //    lightbulbStand2.SetActive(true);
    //}
    //public void Stand3()
    //{
    //    lightbulbStand3.SetActive(true);
    //}

    public void LockUiUp()
    {
        Lock1.gameObject.SetActive(true);
    }
    public void LockUiOff()
    {
        Lock1.gameObject.SetActive(false);
    }

    public void LightsOn()
    {
        globalLight.SetActive(true);
    }
    public void LightsOff()
    {
        globalLight.SetActive(false);
    }

    //public void EnemeyOn()
    //{
    //    enemy.SetActive(true);
    //}

    //public void ShadowRun()
    //{
    //    StartCoroutine(ShadowRunEnum());
    //}
    //IEnumerator ShadowRunEnum()
    //{
    //    shadowanim.SetBool("shadow bool", true);
    //    yield return new WaitForSeconds(1);
    //    Destroy(shadow);
    //}

    public void DoorSFXon()
    {
        doorUnlockSFX.Play();
        pc.playerLock = false;
    }
}
