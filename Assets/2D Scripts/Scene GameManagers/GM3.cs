using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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

    //Enemy Stuff
    public GameObject burnedEnemyPrefab;
    public BurnedEnemy be;
    public GameObject SpawnedBE;

    // Swap Points for the Enemy
    public Transform spawnPointsGroup;
    public Transform[] spawnPoints;
    public int spawnNo;

    // Timer for the Enemy
    public float timer;
    public bool timerGate;

    // Lights on the Player entery
    public Light2D normalLight;
    public Light2D redLight;

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
        spawnPoints = spawnPointsGroup.GetComponentsInChildren<Transform>();

        redLight.gameObject.SetActive(false);

        timerGate = true;
        timer = 60f;  //start time before the enemy spawns


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
    //Burned Enemy Stuffs 
    public void ChooseSpawnPoint()
    {
        spawnNo = Random.Range(0, spawnPoints.Length);
        float d = Vector2.Distance(p.transform.position, spawnPoints[spawnNo].transform.position);
        if (d < 10f)
        {
            ChooseSpawnPoint();
        }
    }


    IEnumerator SpawnBE()
    {
        yield return new WaitForSeconds(timer);

        normalLight.gameObject.SetActive(false);
        redLight.gameObject.SetActive(true);

        ChooseSpawnPoint();

        SpawnedBE = Instantiate(burnedEnemyPrefab, spawnPoints[spawnNo].transform.position, Quaternion.identity);
        SpawnedBE.transform.position = new Vector3(spawnPoints[spawnNo].transform.position.x, -17.9f, transform.position.z);
        be = SpawnedBE.GetComponent<BurnedEnemy>();
        yield return new WaitForSeconds(0.001f);
        be.FlipSpriteCheck();

        yield return new WaitForSeconds(15f);

        if (SpawnedBE != null)
            Destroy(SpawnedBE);
        normalLight.gameObject.SetActive(true);
        redLight.gameObject.SetActive(false);

        timer = Random.Range(20f, 120f);
        timerGate = true;
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

    private void Update()
    {
        if (timerGate)
        {
            timerGate = false;
            StartCoroutine(SpawnBE());
        }
    }

}
