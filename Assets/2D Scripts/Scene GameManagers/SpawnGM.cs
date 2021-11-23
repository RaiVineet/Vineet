using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnGM : MonoBehaviour
{
    private static SpawnGM instance;

    public GameObject _GM1;
    public GM1 _gm1;
    public GameObject _GM15;
    public GM15 _gm15;
    public GameObject _GM17;
    public GM17 _gm17;

    public GameObject LockedDoor;         //1-0
    public bool lightbulbStand1Bool;
    public bool lightbulbStand2Bool;
    public bool lightbulbStand3Bool;
    public bool level1;
    public bool level1DoorBool;
    public bool level1Light1;
    public bool level1Light2;
    public bool level1Light3;
    public GameObject battery1obj;
    public bool battery1;
    public GameObject Lighter;         
    public bool level11;
    public bool level11Lighter;

    public GameObject Lightbulb;        //1-1
    public bool level12LightBulb;

    public GameObject Lightbulb2;       //1-3
    public bool level13;
    public bool level13LightBulb;
    public GameObject battery13obj;
    public bool battery13;

    public GameObject Door3;            //1-5
    public GameObject AccessDoor17;
    public bool level15;
    public bool level15DoorBool;

    public GameObject Lightbulb3;       //1-6
    public bool level16;
    public bool level16Key;
    public bool level16LightBulb;

    public GameObject sprayCan;
    public bool level2;
    public bool level2spraycan;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        level1 = true;
        level1DoorBool = false;
        lightbulbStand1Bool = false;
        lightbulbStand2Bool = false;
        lightbulbStand3Bool = false;
        battery1 = false;
        level11 = true;
        level11Lighter = false;
        level12LightBulb = false;
        level13 = true;
        level13LightBulb = false;
        battery13 = false;
        level15 = true;
        level15DoorBool = false;
        level16 = true;
        level16Key = false;
        level16LightBulb = false;
        level2 = true;
        level2spraycan = false;
    }

    IEnumerator Level1()
    {
        level1 = false;
        yield return new WaitForSeconds(0.5f);
        _GM1 = GameObject.Find("Level1GameManager");
        if (_GM1 != null)
            _gm1 = _GM1.GetComponent<GM1>();
        
        LockedDoor = GameObject.Find("Locked Door");
        if (level1DoorBool)
        {
            if (LockedDoor != null)
            {
                Destroy(LockedDoor);
            }
            _gm1.AccessDoorOn();
        }
        //if (lightbulbStand1Bool)
        //{
        //    _gm1.Stand1();
        //}
        //if (lightbulbStand2Bool)
        //{
        //    _gm1.Stand2();
        //}
        //if (lightbulbStand3Bool)
        //{
        //    _gm1.Stand3();
        //}
        battery1obj = GameObject.Find("Battery10");
        if (battery1)
        {
            Destroy(battery1obj);
        }
        
        Lighter = GameObject.Find("Lighter");
        if (level11Lighter)
        {
            Destroy(Lighter);
        }
    }

    IEnumerator Level11()
    {
        yield return new WaitForSeconds(0.1f);
        level11 = false;
        Lightbulb = GameObject.Find("Lightbulb1");
        if (level12LightBulb)
        {
            Destroy(Lightbulb);
        }
    }

    IEnumerator Level13()
    {
        level13 = false;
        yield return new WaitForSeconds(0.1f);
        Lightbulb2 = GameObject.Find("Lightbulb2");
        if (level13LightBulb)
        {
            Destroy(Lightbulb2);
        }
        battery13obj = GameObject.Find("Battery13");
        if (battery13)
        {
            Destroy(battery13obj);
        }
    }

    IEnumerator Level15()
    {
        level15 = false;
        yield return new WaitForSeconds(0.1f);
        _GM15 = GameObject.Find("GameManager15");
        if (_GM15 != null)
            _gm15 = _GM15.GetComponent<GM15>();
        Door3 = GameObject.Find("Door3");
        if (level15DoorBool)
        {
            Destroy(Door3);
            _gm15.AccessDoorOn();
        }
    }

    IEnumerator Level16()
    {
        level16 = false;
        yield return new WaitForSeconds(0.1f);
        Lightbulb3 = GameObject.Find("Lightbulb3");
        if (level16LightBulb)
        {
            Destroy(Lightbulb3);
        }
    }

    IEnumerator Level2()
    {
        level2 = false;
        yield return new WaitForSeconds(0.1f);
        sprayCan = GameObject.Find("Spray Can");
        if (level2spraycan)
        {
            Destroy(sprayCan);
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level 1" && level1)
            StartCoroutine(Level1());
        if (sceneName != "Level 1")
            level1 = true;

        if (sceneName == "Level 1-1" && level11)
            StartCoroutine(Level11());
        if (sceneName != "Level 1-1")
            level11 = true;

        if (sceneName == "Level 1-3" && level13)
            StartCoroutine(Level13());
        if (sceneName != "Level 1-3")
            level13 = true;

        if (sceneName == "Level 1-5" && level15)
            StartCoroutine(Level15());
        if (sceneName != "Level 1-5")
            level15 = true;

        if (sceneName == "Level 1-6" && level16)
            StartCoroutine(Level16());
        if (sceneName != "Level 1-6")
            level16 = true;

        if (sceneName == "Level 2" && level2)
            StartCoroutine(Level2());
        if (sceneName != "Level 2")
            level2 = true;
    }
}
