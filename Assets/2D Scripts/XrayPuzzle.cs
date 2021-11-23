using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayPuzzle : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;
    public GameObject _GM2;
    public GM2 _gm2;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;
    public GameObject b9;
    public GameObject b10;
    public GameObject b11;
    public GameObject b12;
    public GameObject b13;
    public GameObject b14;
    public GameObject b15;

    public bool bool1;
    public bool bool2;
    public bool bool3;
    public bool bool4;
    public bool bool5;
    public bool bool6;
    public bool bool7;
    public bool bool8;
    public bool bool9;
    public bool bool10;
    public bool bool11;
    public bool bool12;
    public bool bool13;
    public bool bool14;
    public bool bool15;

    public GameObject _b1;
    public GameObject _b2;
    public GameObject _b3;
    public GameObject _b4;
    public GameObject _b5;
    public GameObject _b6;
    public GameObject _b7;
    public GameObject _b8;
    public GameObject _b9;
    public GameObject _b10;
    public GameObject _b11;
    public GameObject _b12;
    public GameObject _b13;
    public GameObject _b14;
    public GameObject _b15;

    public int count;

    void Start()
    {
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        _GM2 = GameObject.Find("Level2GameManager");
        if (_GM2 != null)
            _gm2 = _GM2.gameObject.GetComponent<GM2>();

        bool1 = false;
        bool2 = false;
        bool3 = false;
        bool4 = false;
        bool5 = false;
        bool6 = false;
        bool7 = false;
        bool8 = false;
        bool9 = false;
        bool10 = false;
        bool11 = false;
        bool12 = false;
        bool13 = false;
        bool14 = false;
        bool15 = false;

        _b1.SetActive(false);
        _b2.SetActive(false);
        _b3.SetActive(false);
        _b4.SetActive(false);
        _b5.SetActive(false);
        _b6.SetActive(false);
        _b7.SetActive(false);
        _b8.SetActive(false);
        _b9.SetActive(false);
        _b10.SetActive(false);
        _b11.SetActive(false);
        _b12.SetActive(false);
        _b13.SetActive(false);
        _b14.SetActive(false);
        _b15.SetActive(false);

        count = 0;
    }

    public void B1()
    {
        bool1 = true;
        _b1.SetActive(true);
        count++;
    }
    public void B2()
    {
        bool2 = true;
        _b2.SetActive(true);
        count++;
    }
    public void B3()
    {
        bool3 = true;
        _b3.SetActive(true);
        count++;
    }
    public void B4()
    {
        bool4 = true;
        _b4.SetActive(true);
        count++;
    }
    public void B5()
    {
        bool5 = true;
        _b5.SetActive(true);
        count++;
    }
    public void B6()
    {
        bool6 = true;
        _b6.SetActive(true);
        count++;
    }
    public void B7()
    {
        bool7 = true;
        _b7.SetActive(true);
        count++;
    }
    public void B8()
    {
        bool8 = true;
        _b8.SetActive(true);
        count++;
    }
    public void B9()
    {
        bool9 = true;
        _b9.SetActive(true);
        count++;
    }
    public void B10()
    {
        bool10 = true;
        _b10.SetActive(true);
        count++;
    }
    public void B11()
    {
        bool11 = true;
        _b11.SetActive(true);
        count++;
    }
    public void B12()
    {
        bool12 = true;
        _b12.SetActive(true);
        count++;

    }
    public void B13()
    {
        bool13 = true;
        _b13.SetActive(true);
        count++;
    }
    public void B14()
    {
        bool14 = true;
        _b14.SetActive(true);
        count++;
    }
    public void B15()
    {
        bool15 = true;
        _b15.SetActive(true);
        count++;
    }

    private void Update()
    {
        if (count >= 8)
        {
            if (bool1 && bool3 && bool4 && bool5 && bool10 && bool11 && bool12 && bool15)
            {
                _gm2.XrayComplete();
                _gm2.xrayCollider.GetComponent<BoxCollider>().enabled = false;
                _gm2.papers.SetActive(true);
                count = 0;
                pc.InspectText.text = "Did I... Were those papers always there?";
                pc.TextUp();
            }
            else
            {
                bool1 = false;
                bool2 = false;
                bool3 = false;
                bool4 = false;
                bool5 = false;
                bool6 = false;
                bool7 = false;
                bool8 = false;
                bool9 = false;
                bool10 = false;
                bool11 = false;
                bool12 = false;
                bool13 = false;
                bool14 = false;
                bool15 = false;

                count = 0;

                _b1.SetActive(false);
                _b2.SetActive(false);
                _b3.SetActive(false);
                _b4.SetActive(false);
                _b5.SetActive(false);
                _b6.SetActive(false);
                _b7.SetActive(false);
                _b8.SetActive(false);
                _b9.SetActive(false);
                _b10.SetActive(false);
                _b11.SetActive(false);
                _b12.SetActive(false);
                _b13.SetActive(false);
                _b14.SetActive(false);
                _b15.SetActive(false);
            }
        }
    }
}
