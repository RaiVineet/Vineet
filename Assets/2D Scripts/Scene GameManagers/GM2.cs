using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class GM2 : MonoBehaviour
{

    public GameObject burnedEnemyPrefab;
    public BurnedEnemy be;
    public GameObject SpawnedBE;

    public GameObject lighter;

    public Light2D normalLight;
    public Light2D redLight;

    public Transform spawnPointsGroup;
    public Transform[] spawnPoints;
    public int spawnNo;

    public GameObject openDoortoLevel3;

    public GameObject combiLock1;
    public GameObject combiLock2;
    public GameObject cabinet;
    public GameObject cabinet2;

    public PuzzleUI PUI;

    public GameObject xrayCollider;
    public GameObject XrayUI;
    public GameObject papers;
    public GameObject BackstoryFile;
    public Animator anim;
    public float timer;
    public bool timerGate;

    public GameObject p;
    public PlayerControl pc;


    private void Start()
    {
        spawnPoints = spawnPointsGroup.GetComponentsInChildren<Transform>();
        // pc.SceneAccessOff();
        //redLight.gameObject.SetActive(false);
        openDoortoLevel3.SetActive(false);
        xrayCollider.GetComponent<BoxCollider>().enabled = false;
        papers.SetActive(false);
        PUI = xrayCollider.GetComponent<PuzzleUI>();

        timerGate = true;
        timer = 60f;        //start time before the enemy spawns

        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
            Debug.Log("Got the player");
        }

        if (pc.haveLighter)
        {
            Destroy(lighter);
        }
        StartCoroutine(Checkpoint());
    }

    IEnumerator Checkpoint()
    {

        yield return new WaitForSeconds(1);
        pc.SavePlayer();
        pc.FindOnScene();

    }

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

        //normalLight.gameObject.SetActive(false);
        //redLight.gameObject.SetActive(true);

        ChooseSpawnPoint();

        SpawnedBE = Instantiate(burnedEnemyPrefab, spawnPoints[spawnNo].transform.position, Quaternion.identity);
        SpawnedBE.transform.position = new Vector3(spawnPoints[spawnNo].transform.position.x, -17.9f, transform.position.z);
        be = SpawnedBE.GetComponent<BurnedEnemy>();
        yield return new WaitForSeconds(0.001f);
        be.FlipSpriteCheck();

        yield return new WaitForSeconds(15f);

        if (SpawnedBE != null)
            Destroy(SpawnedBE);
        //normalLight.gameObject.SetActive(true);
        //redLight.gameObject.SetActive(false);

        timer = Random.Range(20f, 120f);
        timerGate = true;
    }

    public void UnlockCombi1()
    {
        combiLock1.SetActive(false);
        PUI.PuzzlesOn();
        cabinet.GetComponent<BoxCollider>().enabled = false;
    }
    public void UnlockCombi2()
    {
        combiLock2.SetActive(false);
        PUI.PuzzlesOn();
        cabinet2.GetComponent<BoxCollider>().enabled = false;
    }

    public void XrayComplete()
    {
        XrayUI.SetActive(false);
        PUI.PuzzlesOn();
        pc.playerLock = false;
    }

    public void OpenLevel3()
    {
        openDoortoLevel3.SetActive(true);
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








//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.Rendering.Universal;

//public class GM2 : MonoBehaviour
//{

//    public GameObject burnedEnemyPrefab;
//    public BurnedEnemy be;
//    public GameObject SpawnedBE;

//    public GameObject lighter;

//    public Light2D normalLight;
//    public Light2D redLight;

//    public Transform spawnPointsGroup;
//    public Transform[] spawnPoints;
//    public int spawnNo;

//    public GameObject openDoortoLevel3;

//    public GameObject combiLock1;
//    public GameObject combiLock2;
//    public GameObject cabinet;
//    public GameObject cabinet2;

//    public PuzzleUI PUI;

//    public GameObject xrayCollider;
//    public GameObject XrayUI;
//    public GameObject papers;
//    public GameObject BackstoryFile;
//    public Animator anim;
//    public float timer;
//    public bool timerGate;

//    public GameObject p;
//    public PlayerControl pc;


//    private void Start()
//    {
//        spawnPoints = spawnPointsGroup.GetComponentsInChildren<Transform>();
//        // pc.SceneAccessOff();
//        redLight.gameObject.SetActive(false);
//        openDoortoLevel3.SetActive(false);
//        xrayCollider.GetComponent<BoxCollider>().enabled = false;
//        papers.SetActive(false);
//        PUI = xrayCollider.GetComponent<PuzzleUI>();

//        timerGate = true;
//        timer = 5f;        //start time before the enemy spawns

//        if (p == null)
//        {
//            p = GameObject.FindGameObjectWithTag("Player");
//            pc = p.GetComponent<PlayerControl>();
//        }

//        if (pc.haveLighter)
//        {
//            Destroy(lighter);
//        }
//        StartCoroutine(Checkpoint());
//    }

//    IEnumerator Checkpoint()
//    {

//        yield return new WaitForSeconds(1);
//        pc.SavePlayer();
//        pc.FindOnScene();

//    }

//    public void ChooseSpawnPoint()
//    {
//        spawnNo = Random.Range(0, spawnPoints.Length);
//        float d = Vector2.Distance(p.transform.position, spawnPoints[spawnNo].transform.position);
//        if (d < 10f)
//        {
//            ChooseSpawnPoint();
//        }
//    }

//    IEnumerator SpawnBE()
//    {
//        yield return new WaitForSeconds(timer);

//        normalLight.gameObject.SetActive(false);
//        redLight.gameObject.SetActive(true);

//        ChooseSpawnPoint();

//        SpawnedBE = Instantiate(burnedEnemyPrefab, spawnPoints[spawnNo].transform.position, Quaternion.identity);
//        SpawnedBE.transform.position = new Vector3(spawnPoints[spawnNo].transform.position.x, -17.9f, transform.position.z);
//        be = SpawnedBE.GetComponent<BurnedEnemy>();
//        yield return new WaitForSeconds(0.001f);
//        be.FlipSpriteCheck();

//        yield return new WaitForSeconds(15f);

//        if (SpawnedBE != null)
//            Destroy(SpawnedBE);
//        normalLight.gameObject.SetActive(true);
//        redLight.gameObject.SetActive(false);

//        timer = Random.Range(20f, 120f);
//        timerGate = true;
//    }

//    public void UnlockCombi1()
//    {
//        combiLock1.SetActive(false);
//        PUI.PuzzlesOn();
//        cabinet.GetComponent<BoxCollider>().enabled = false;
//    }
//    public void UnlockCombi2()
//    {
//        combiLock2.SetActive(false);
//        PUI.PuzzlesOn();
//        cabinet2.GetComponent<BoxCollider>().enabled = false;
//    }

//    public void XrayComplete()
//    {
//        XrayUI.SetActive(false);
//        PUI.PuzzlesOn();
//        pc.playerLock = false;
//    }

//    public void OpenLevel3()
//    {
//        openDoortoLevel3.SetActive(true);
//    }

//    private void Update()
//    {
//        pc.SceneAccessOff();
//        if (timerGate)
//        {
//            timerGate = false;
//            StartCoroutine(SpawnBE());
//        }
//    }
//}
