using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GM3 : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;
    

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

   



    public GameObject combLock_1;  // room 1 lock
    public GameObject Cabneit_1;   // room 1 cabinet lock

    public GameObject CombLock_2;  // Room2 Lock
    public GameObject Cabneit_2;  // Room 2 Cabinet

    public GameObject combLock_3;  // room 3 lock
    public GameObject Cabneit_3;   // room 3 cabinet lock

    public GameObject combLock_4;  // room  4 lock
    public GameObject Cabneit_4;   // room 4 cabinet lock

    public PuzzleUI PUI;
    public GameObject stackofpaper;
    public GameObject stackofFiles;
    public GameObject BackstoryFile;

    // Doors
    public GameObject OpenDoor1;


    void Start()
    {
        spawnPoints = spawnPointsGroup.GetComponentsInChildren<Transform>(); // Enemy swap points 
        redLight.gameObject.SetActive(false);

        timerGate = true;
        timer = 120f;  //start time before the enemy spawns


        

        CombLock_2.SetActive(false);
        combLock_3.SetActive(false);
        combLock_4.SetActive(false);
        OpenDoor1.SetActive(false);

       

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

    // Spawn the Burned Enemy
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

    // lock 1
    public void UnlockCombi1()
    {
        combLock_1.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_1.GetComponent<BoxCollider>().enabled = false;
    }
    // lock2
    public void UnlockComb_2()
    {
        CombLock_2.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_2.GetComponent<BoxCollider>().enabled = false;
    }
    //lock 3
    public void UnlockComb_3()
    {
        combLock_3.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_3.GetComponent<BoxCollider>().enabled = false;
    }
    // lock 4
    public void UnlockComb_4()
    {
        combLock_4.SetActive(false); //  if the player achive the clue than the disappaer the lock 
        PUI.PuzzlesOn();
        Cabneit_4.GetComponent<BoxCollider>().enabled = false;
    }

   

    private void Update()
    {
        pc.SceneAccessOff();
        if (timerGate)
        {
            timerGate = false;
            StartCoroutine(SpawnBE());
        }
    }

}
