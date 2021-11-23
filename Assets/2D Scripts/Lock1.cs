using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock1 : MonoBehaviour
{
    public GameObject p;
    public PlayerControl pc;
    public GameObject _GM1;
    public GM1 _gm1;
    public GameObject _GM2;
    public GM2 _gm2;
    public GameObject _SpawnGM;
    public GameObject _GM3;
    public GM3 _gm3;
    public SpawnGM _sgm;

    public GameObject DoorLock;
    public GameObject DoorLock2;
    public GameObject DoorLock3;
    public GameObject ClickOutobj;
    public ClickoutUI co;

    public Button up1;
    public Button up2;
    public Button up3;
    public Button up4;
    public Button up5;
    public Button down1;
    public Button down2;
    public Button down3;
    public Button down4;
    public Button down5;
    public Button go;

    public Text oneText;
    public Text twoText;
    public Text threeText;
    public Text fourText;
    public Text fiveText;

    public string oneA;
    public string oneB;
    public string oneC;
    public string oneD;
    public string oneE;
    public string twoA;
    public string twoB;
    public string twoC;
    public string twoD;
    public string twoE;
    public string threeA;
    public string threeB;
    public string threeC;
    public string threeD;
    public string threeE;
    public string fourA;
    public string fourB;
    public string fourC;
    public string fourD;
    public string fourE;
    public string fiveA;
    public string fiveB;
    public string fiveC;
    public string fiveD;
    public string fiveE;

    public int one;
    public int two;
    public int three;
    public int four;
    public int five;

    private void Start()
    {
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        _GM1 = GameObject.Find("Level1GameManager");

        if (_GM1 != null)
            _gm1 = _GM1.gameObject.GetComponent<GM1>();

        _GM2 = GameObject.Find("Level2GameManager");

        if (_GM2 != null)
            _gm2 = _GM2.gameObject.GetComponent<GM2>();

        _GM3 = GameObject.Find("Level3GameManager");

        if(_GM3 != null)
            _gm3 = _GM3.gameObject.GetComponent<GM3>(); 




        _SpawnGM = GameObject.Find("SpawnGM");

        if (_SpawnGM != null)
            _sgm = _SpawnGM.GetComponent<SpawnGM>();

        if (ClickOutobj != null)
            co = ClickOutobj.GetComponent<ClickoutUI>();

        one = 1;
        oneText.text = oneA;
        two = 1;
        twoText.text = twoA;
        three = 1;
        threeText.text = threeA;
        four = 1;
        fourText.text = fourA;
        five = 1;
        fiveText.text = fiveA;
    }

    public void Up1()
    {
        switch (one)
        {
            case 1:
                oneText.text = oneA;
                break;
            case 2:
                one = 1;
                oneText.text = oneA;
                break;
            case 3:
                one = 2;
                oneText.text = oneB;
                break;
            case 4:
                one = 3;
                oneText.text = oneC;
                break;
            case 5:
                one = 4;
                oneText.text = oneD;
                break;
        }
    }
    public void Down1()
    {
        switch (one)
        {
            case 1:
                one = 2;
                oneText.text = oneB;
                break;
            case 2:
                one = 3;
                oneText.text = oneC;
                break;
            case 3:
                one = 4;
                oneText.text = oneD;
                break;
            case 4:
                one = 5;
                oneText.text = oneE;
                break;
            case 5:
                oneText.text = oneE;
                break;
        }
    }

    public void Up2()
    {
        switch (two)
        {
            case 1:
                twoText.text = twoA;
                break;
            case 2:
                two = 1;
                twoText.text = twoA;
                break;
            case 3:
                two = 2;
                twoText.text = twoB;
                break;
            case 4:
                two = 3;
                twoText.text = twoC;
                break;
            case 5:
                two = 4;
                twoText.text = twoD;
                break;
        }
    }
    public void Down2()
    {
        switch (two)
        {
            case 1:
                two = 2;
                twoText.text = twoB;
                break;
            case 2:
                two = 3;
                twoText.text = twoC;
                break;
            case 3:
                two = 4;
                twoText.text = twoD;
                break;
            case 4:
                two = 5;
                twoText.text = twoE;
                break;
            case 5:
                twoText.text = twoE;
                break;
        }
    }

    public void Up3()
    {
        switch (three)
        {
            case 1:
                threeText.text = threeA;
                break;
            case 2:
                three = 1;
                threeText.text = threeA;
                break;
            case 3:
                three = 2;
                threeText.text = threeB;
                break;
            case 4:
                three = 3;
                threeText.text = threeC;
                break;
            case 5:
                three = 4;
                threeText.text = threeD;
                break;
        }
    }
    public void Down3()
    {
        switch (three)
        {
            case 1:
                three = 2;
                threeText.text = threeB;
                break;
            case 2:
                three = 3;
                threeText.text = threeC;
                break;
            case 3:
                three = 4;
                threeText.text = threeD;
                break;
            case 4:
                three = 5;
                threeText.text = threeE;
                break;
            case 5:
                threeText.text = threeE;
                break;
        }
    }

    public void Up4()
    {
        switch (four)
        {
            case 1:
                fourText.text = fourA;
                break;
            case 2:
                four = 1;
                fourText.text = fourA;
                break;
            case 3:
                four = 2;
                fourText.text = fourB;
                break;
            case 4:
                four = 3;
                fourText.text = fourC;
                break;
            case 5:
                four = 4;
                fourText.text = fourD;
                break;
        }
    }
    public void Down4()
    {
        switch (four)
        {
            case 1:
                four = 2;
                fourText.text = fourB;
                break;
            case 2:
                four = 3;
                fourText.text = fourC;
                break;
            case 3:
                four = 4;
                fourText.text = fourD;
                break;
            case 4:
                four = 5;
                fourText.text = fourE;
                break;
            case 5:
                fourText.text = fourE;
                break;
        }
    }

    public void Up5()
    {
        switch (five)
        {
            case 1:
                fiveText.text = fiveA;
                break;
            case 2:
                five = 1;
                fiveText.text = fiveA;
                break;
            case 3:
                five = 2;
                fiveText.text = fiveB;
                break;
            case 4:
                five = 3;
                fiveText.text = fiveC;
                break;
            case 5:
                five = 4;
                fiveText.text = fiveD;
                break;
        }

    }
    public void Down5()
    {
        switch (five)
        {
            case 1:
                five = 2;
                fiveText.text = fiveB;
                break;
            case 2:
                five = 3;
                fiveText.text = fiveC;
                break;
            case 3:
                five = 4;
                fiveText.text = fiveD;
                break;
            case 4:
                five = 5;
                fiveText.text = fiveE;
                break;
            case 5:
                fiveText.text = fiveE;
                break;
        }
    }

    public void Go1()  // HAPPY
    {
        if (one == 3 && two == 5 && three == 1 && four == 4 && five == 4)
        {
            pc.playerLock = false;
            _gm1.LockUiOff();
            _gm1.NextLevelDoor();
        }
    }
    public void Go31()  /// SCARY

    {
        if (one == 3 && two == 2 && three == 4 && four == 5 && five == 2)
        {
            _gm3.UnlockCombi1();
            _gm3.UnlockComb_2();
            DoorLock.SetActive(false);
           
            pc.InspectText.text = "door open ";
            pc.prefabItem = pc.KeyItem3;
            pc.ItemSlotCheck();
            pc.ItemSlotDeposit(); 
            pc.TextUp();
            _gm3.EnterCollider.GetComponent<BoxCollider>().enabled = true;
            co.Out();
        }
        else
        {
            pc.InspectText.text = "Wrong Code";
            pc.TextUp();
            co.Out();
        }
    }
    public void Go32()  /// rocky

    {
        if (one == 3 && two == 2 && three == 4 && four == 5 && five == 2)
        {
            //_gm3.UnlockCombi1();
            _gm3.UnlockComb_2();
            _gm3.CombLock_2.SetActive(false);
            DoorLock.SetActive(false);
            pc.InspectText.text = "You got a special key";
            pc.TextUp();
            pc.prefabItem = pc.KeyItem3;
            pc.ItemSlotCheck();
            pc.ItemSlotDeposit();
            co.Out();
        }
        else
        {
            pc.InspectText.text = "Wrong Code";
            pc.TextUp();
            co.Out();
        }
    }
    public void Go33()  ///  MUSIC 

    {
        if (one == 3 && two == 2 && three == 4 && four == 5 && five == 2)
        {
            //_gm3.UnlockCombi1();
            _gm3.UnlockComb_3();
            _gm3.combLock_3.SetActive(false);
            DoorLock3.SetActive(false);
            pc.InspectText.text = "You got a special key";
            pc.TextUp();
            pc.prefabItem = pc.KeyItem3;
            pc.ItemSlotCheck();
            pc.ItemSlotDeposit();
            co.Out();
        }
        else
        {
            pc.InspectText.text = "Wrong Code";
            pc.TextUp();
            co.Out();
        }
    }

    public void Go2()// level 2 blood 
    {
        if (one == 3 && two == 2 && three == 4 && four == 5 && five == 2)
        {
            _gm2.UnlockCombi1();
            pc.InspectText.text = "There's a little blue light in here. It's showing somehting on that xray.";
            pc.TextUp();
            _gm2.xrayCollider.GetComponent<BoxCollider>().enabled = true;

            co.Out();
        }
    }
    public void Go22() // APHAR
    {
        if (one == 1 && two == 3 && three == 5 && four == 2 && five == 2)
        {
            _gm2.UnlockCombi2();
            pc.InspectText.text = "There's a key in here.";
            pc.TextUp();
            pc.prefabItem = pc.KeyItem5;
            pc.ItemSlotCheck();
            pc.ItemSlotDeposit();
            co.Out();
        }
    }
   
    public void Out()
    {
        _gm1.LockUiOff();
    }
    
    public void OutPuzzle()
    {
        pc.playerLock = false;
    }
}
