using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask layerMASK; // layer for the platform
    private static PlayerControl instance;
    public GameObject _fadeObj;
    public Fade _fade;
    public bool FacingRight;
    public GameObject _tutorialGM;
    public TutorialGM tgm;
    public GameObject _GM1;
    public GM1 _gm1;
    public GameObject _GM15;
    public GM15 _gm15;
    public GameObject _GM2;
    public GM2 _gm2;
    public GameObject _GM3;
    public GM3 _gm3;
    public GameObject _SpawnGM;
    public SpawnGM _sgm;

    public SpriteRenderer mySprite;
    public GameObject Mal;
    private FootstepsSoundEffect footstepsSound;


    private Vector2 target;
    public GameObject itemObj;
    public GameObject UseObj;
    public GameObject flashlightHand;
    public GameObject flashlight;
    public GameObject Lighter;
    public GameObject flameThrower;
    //public GameObject flames;
    public bool haveFlashlight;
    public bool haveLighter;
    public bool haveSprayCan;
    public Slider StaminaImg;
    public float stam;
    public bool stamBool;
    public Slider HPImg;
    public float hp;
    public Slider BatteryImg;
    public float batteryLife;

    public Canvas UICanvas;
    public GameObject ItemSlotParent;
    public Transform[] ItemSlots;    //itemslot positions in the inventory (an empty gameobject sits where they are)
    public Transform emptyItemSlot;
    public GameObject TempIteminInventory;
    public PuzzleUI puzzle;

    public bool playerLock;

    public GameObject prefabItem;   //an empty prefab to select them from the switch statement
    public GameObject KeyItem;   //make these images for the inventory screen buttons so you can click and use them
    public GameObject KeyItem2;
    public GameObject KeyItem3;
    public GameObject KeyItem4;
    public GameObject KeyItem5;
    public GameObject KeyItem6;
    public GameObject flashlightUIprefab;
    public GameObject flashlightprefab;
    public GameObject LighterUIPrefab;
    public GameObject LighterPrefab;
    public GameObject flameThrowerPrefab;
    public GameObject Lightbulb1Prefab;
    public GameObject Lightbulb2Prefab;
    public GameObject Lightbulb3Prefab;
    public GameObject SprayCanPrefab;
    private string storedUseItemRef = "";

    public TextMeshProUGUI InspectText;

    public bool itemlock;
    public bool itemUseBool;
    public bool movingToObject;
    public bool flashlightDrain;

    private float movementSpeed;
    public float jumpVelocity;
    public float sprint;
    public float horizontal;
    public Kick k;
    public  Rigidbody2D myRigidbody;
    public BoxCollider2D BoxCollider;

    public GameObject pickupSFXobj;
    public AudioSource pickupSFX;
    public AudioSource FootstepSound;
    public AudioSource jumpsounnd;
   // public AudioClip footstep;

    public string sceneAccess;
    public bool sceneAccessBool;
    public bool kickBool;

    public Animator anim;
    public ParticleSystem FlamethrowerFlames;

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

    private void Start()
    {
        
        _fadeObj = GameObject.FindGameObjectWithTag("Fade");
        _fade = _fadeObj.GetComponent<Fade>();

        FindOnScene();

        myRigidbody = GetComponent<Rigidbody2D>();
        BoxCollider = transform.GetComponent<BoxCollider2D>();
        movementSpeed = 5f;
        jumpVelocity = 25f;
        horizontal = 0;
        stam = 1f;
        hp = 1f;
        batteryLife = 1f;
        target = new Vector2(transform.position.x, transform.position.y);
        itemlock = false;
        itemUseBool = false;
        movingToObject = false;
        InspectText.enabled = false;
        sceneAccessBool = false;
        kickBool = false;
        playerLock = false;
        stamBool = true;
        haveFlashlight = false;
        haveLighter = false;
        haveSprayCan = false;
        flashlightDrain = false;

        ItemSlots = ItemSlotParent.GetComponentsInChildren<Transform>();

        mySprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        pickupSFX = pickupSFXobj.GetComponent<AudioSource>();
       
    }
    public void Flip()
    {
       

        if (FacingRight)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180.0f, transform.localEulerAngles.z) ;

        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0.0f, transform.localEulerAngles.z);
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void Respawn()   //call this when HP = 0
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManager.LoadScene(data.levelName);
        hp = data.hp;
        batteryLife = data.BatteryLife;
        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
        haveFlashlight = data.haveFlashlight;
        haveLighter = data.haveLighter;
        haveSprayCan = data.haveSprayCan;
        //RespawnHand();

        FindOnScene();

        RespawnItemSlot1();
        RespawnItemSlot2();
        RespawnItemSlot3();
        RespawnItemSlot4();
        RespawnItemSlot5();
        RespawnItemSlot6();
    }

    void RespawnHand()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.handslot)   //switch statement to find the prefab of the item's namesake
        {
             
            case "LighterUsePrefab(Clone)":
                Lighter = Instantiate(LighterPrefab, flashlightHand.transform.position, Quaternion.identity);
                Lighter.transform.SetParent(flashlightHand.transform, false);
                Lighter.transform.position = flashlightHand.transform.position;
                break;
            case "flashlight(Clone)":
                flashlight = Instantiate(flashlightprefab, flashlightHand.transform.position, Quaternion.identity);
                flashlight.transform.SetParent(flashlightHand.transform, false);
                flashlight.transform.position = flashlightHand.transform.position;
                flashlightDrain = true;
                break;
               
        }

    }
    void RespawnItemSlot1()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.Itemslot1)   //switch statement to find the prefab of the item's namesake
        {
            case "LighterPrefab(Clone)":
                prefabItem = LighterUIPrefab;
                break;
            case "FlashlightPrefab(Clone)":
                prefabItem = flashlightUIprefab;
                break;
            case "SprayCanPrefab(Clone)":
                prefabItem = SprayCanPrefab;
                break;
            case "Key3Prefab(Clone)":
                prefabItem = KeyItem3;
                break;
            case "Lightbulb1Prefab(Clone)":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2Prefab(Clone)":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3Prefab(Clone)":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
        }

        var pickupItem = Instantiate(prefabItem, ItemSlots[1].position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(ItemSlots[1], false);
        pickupItem.transform.position = ItemSlots[1].position;

        prefabItem = null;
    }
    void RespawnItemSlot2()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.Itemslot2)   //switch statement to find the prefab of the item's namesake
        {
            case "LighterPrefab(Clone)":
                prefabItem = LighterUIPrefab;
                break;
            case "FlashlightPrefab(Clone)":
                prefabItem = flashlightUIprefab;
                break;
            case "SprayCanPrefab(Clone)":
                prefabItem = SprayCanPrefab;
                break;
            case "Key3Prefab(Clone)":
                prefabItem = KeyItem3;
                break;
            case "Lightbulb1Prefab(Clone)":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2Prefab(Clone)":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3Prefab(Clone)":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
        }

        var pickupItem = Instantiate(prefabItem, ItemSlots[2].position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(ItemSlots[2], false);
        pickupItem.transform.position = ItemSlots[2].position;

        prefabItem = null;
    }
    void RespawnItemSlot3()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.Itemslot3)   //switch statement to find the prefab of the item's namesake
        {
            case "LighterPrefab(Clone)":
                prefabItem = LighterUIPrefab;
                break;
            case "FlashlightPrefab(Clone)":
                prefabItem = flashlightUIprefab;
                break;
            case "SprayCanPrefab(Clone)":
                prefabItem = SprayCanPrefab;
                break;
            case "Key3Prefab(Clone)":
                prefabItem = KeyItem3;
                break;
            case "Lightbulb1Prefab(Clone)":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2Prefab(Clone)":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3Prefab(Clone)":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
        }

        var pickupItem = Instantiate(prefabItem, ItemSlots[3].position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(ItemSlots[3], false);
        pickupItem.transform.position = ItemSlots[3].position;

        prefabItem = null;
    }
    void RespawnItemSlot4()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.Itemslot4)   //switch statement to find the prefab of the item's namesake
        {
            case "LighterPrefab(Clone)":
                prefabItem = LighterUIPrefab;
                break;
            case "FlashlightPrefab(Clone)":
                prefabItem = flashlightUIprefab;
                break;
            case "SprayCanPrefab(Clone)":
                prefabItem = SprayCanPrefab;
                break;
            case "Key3Prefab(Clone)":
                prefabItem = KeyItem3;
                break;
            case "Lightbulb1Prefab(Clone)":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2Prefab(Clone)":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3Prefab(Clone)":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
        }

        var pickupItem = Instantiate(prefabItem, ItemSlots[4].position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(ItemSlots[4], false);
        pickupItem.transform.position = ItemSlots[4].position;

        prefabItem = null;
    }
    void RespawnItemSlot5()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.Itemslot5)   //switch statement to find the prefab of the item's namesake
        {
            case "LighterPrefab(Clone)":
                prefabItem = LighterUIPrefab;
                break;
            case "FlashlightPrefab(Clone)":
                prefabItem = flashlightUIprefab;
                break;
            case "SprayCanPrefab(Clone)":
                prefabItem = SprayCanPrefab;
                break;
            case "Key3Prefab(Clone)":
                prefabItem = KeyItem3;
                break;
            case "Lightbulb1Prefab(Clone)":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2Prefab(Clone)":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3Prefab(Clone)":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
        }

        var pickupItem = Instantiate(prefabItem, ItemSlots[5].position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(ItemSlots[5], false);
        pickupItem.transform.position = ItemSlots[5].position;

        prefabItem = null;
    }
    void RespawnItemSlot6()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (data.Itemslot6)   //switch statement to find the prefab of the item's namesake
        {
            case "LighterPrefab(Clone)":
                prefabItem = LighterUIPrefab;
                break;
            case "FlashlightPrefab(Clone)":
                prefabItem = flashlightUIprefab;
                break;
            case "SprayCanPrefab(Clone)":
                prefabItem = SprayCanPrefab;
                break;
            case "Key3Prefab(Clone)":
                prefabItem = KeyItem3;
                break;
            case "Lightbulb1Prefab(Clone)":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2Prefab(Clone)":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3Prefab(Clone)":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
        }

        var pickupItem = Instantiate(prefabItem, ItemSlots[6].position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(ItemSlots[6], false);
        pickupItem.transform.position = ItemSlots[6].position;

        prefabItem = null;
    }

    public void TakeDamage()
    {
        hp -= 0.34f;

        if (hp <= 0f)
            Respawn();
    }

    public void FindOnScene()
    {
        _tutorialGM = GameObject.Find("TutorialGameManager");
        if (_tutorialGM != null)
            tgm = _tutorialGM.GetComponent<TutorialGM>();

        _GM1 = GameObject.Find("Level1GameManager");
        if (_GM1 != null)
            _gm1 = _GM1.GetComponent<GM1>();

        _GM15 = GameObject.Find("GameManager15");
        if (_GM15 != null)
            _gm15 = _GM15.GetComponent<GM15>();

        _GM2 = GameObject.Find("Level2GameManager");
        if (_GM2 != null)
            _gm2 = _GM2.GetComponent<GM2>();

        _GM3 = GameObject.Find("Level3GameManager");

        if (_GM3 != null)
            _gm3 = _GM3.gameObject.GetComponent<GM3>();


        _SpawnGM = GameObject.Find("SpawnGM");
        if (_SpawnGM != null)
            _sgm = _SpawnGM.GetComponent<SpawnGM>();

    }

    public void PuzzleOut()
    {
        puzzle.Out();
    }

    IEnumerator Pickup()
    {
        anim.SetBool("isPickup", true); //had a pickup animation rigged and working, but it had to be deleted for the 
        //new sprite sheet that only had a walk animation
        yield return new WaitForSeconds(0.5f);

        pickupSFX.Play();

        switch (itemObj.name)   //switch statement to find the prefab of the item's namesake
        {
            case "Key":
                prefabItem = KeyItem;
                break;
            case "Key2":
                prefabItem = KeyItem2;      //set bools here to stop item spawning
                break;
            case "Key3":
                prefabItem = KeyItem3;
                break;
            case "FlashlightPickup":
                prefabItem = flashlightprefab;
                break;
            case "Battery10":
                batteryLife += 0.75f;
                if (batteryLife >= 1f)
                    batteryLife = 1f;
                _sgm.battery1 = true;
                break;
            case "Battery13":
                batteryLife += 0.75f;
                if (batteryLife >= 1f)
                    batteryLife = 1f;
                _sgm.battery13 = true;
                break;
            case "Lighter":
                _sgm.level11Lighter = true;
                haveLighter = true;
                prefabItem = LighterUIPrefab;
                break;
            case "Lightbulb1":
                _sgm.level12LightBulb = true;
                prefabItem = Lightbulb1Prefab;
                break;
            case "Lightbulb2":
                _sgm.level13LightBulb = true;
                prefabItem = Lightbulb2Prefab;
                break;
            case "Lightbulb3":
                _sgm.level16LightBulb = true;
                prefabItem = Lightbulb3Prefab;
                break;
            case "Spray Can":
                prefabItem = SprayCanPrefab;
                haveSprayCan = true;
                _sgm.level2spraycan = true;
                break;
        }

        //copy item to inventory
        if (prefabItem != null)
            ItemSlotCheck();

        if (prefabItem == flashlightprefab)
        {
            EquipFlashlight();
            haveFlashlight = true;
        }
        else
        {
            if (prefabItem != null)
                ItemSlotDeposit();
        }


        //destroy item from world
        Destroy(itemObj);
        itemObj = null;
        prefabItem = null;
        itemlock = false;
        anim.SetBool("isPickup", false);  // pickup animation of the player
    }

    public void ItemSlotCheck()
    {
        for (int i = 0; i < ItemSlots.Length;)
        {
            if (ItemSlots[i].transform.childCount <= 0)
            {
                emptyItemSlot = ItemSlots[i];
                break;
            }
            else
                i++;
        }
    }
    public void ItemSlotDeposit()
    {
        var pickupItem = Instantiate(prefabItem, emptyItemSlot.position, Quaternion.identity);   //need code to determine free item slots
        pickupItem.transform.SetParent(emptyItemSlot, false);
        pickupItem.transform.position = emptyItemSlot.position;
        prefabItem = null;
    }

    public void EquipFlashlight()
    {
        if (batteryLife > 0)
        {
            if (flameThrower != null)
            {
                Destroy(flameThrower);
                Destroy(GameObject.Find("FlashlightPrefab(Clone)"));
                ShuffleItemsBack();
                ItemSlotCheck();
                prefabItem = LighterUIPrefab;
                ItemSlotDeposit();
                ItemSlotCheck();
                prefabItem = SprayCanPrefab;
                ItemSlotDeposit();
            }
            if (Lighter != null)
            {
                Destroy(Lighter);
                Destroy(GameObject.Find("FlashlightPrefab(Clone)"));
                ShuffleItemsBack();
                ItemSlotCheck();
                prefabItem = LighterUIPrefab;
                ItemSlotDeposit();
            }
            flashlight = Instantiate(flashlightprefab, flashlightHand.transform.position, Quaternion.identity);
            flashlight.transform.SetParent(flashlightHand.transform, false);
            flashlight.transform.position = flashlightHand.transform.position;
            flashlightDrain = true;
        }
        else
        {
            InspectText.text = "The battery is flat.";
            StartCoroutine(UseTextEnum());
        }
    }
    public void StowFlashlight()
    {
        flashlightDrain = false;
        InspectText.text = "The battery died.";
        StartCoroutine(UseTextEnum());

        Destroy(flashlight);
        Destroy(GameObject.Find("LighterPrefab(Clone)"));
        ShuffleItemsBack();
        ItemSlotCheck();
        prefabItem = flashlightUIprefab;
        ItemSlotDeposit();
    }

    public void EquipLighter()
    {
        flashlightDrain = false;
        if (flashlight != null)
        {
            Destroy(flashlight);
            Destroy(GameObject.Find("LighterPrefab(Clone)"));
            ShuffleItemsBack();
            ItemSlotCheck();
            prefabItem = flashlightUIprefab;
            ItemSlotDeposit();
        }
        Lighter = Instantiate(LighterPrefab, flashlightHand.transform.position, Quaternion.identity);
        Lighter.transform.SetParent(flashlightHand.transform, false);
        Lighter.transform.position = flashlightHand.transform.position;
    }

    public void CombineSprayCan()
    {
        if (Lighter != null)
        {
            Destroy(Lighter);
            Destroy(GameObject.Find("SprayCanPrefab(Clone)"));
            ShuffleItemsBack();
            flameThrower = Instantiate(flameThrowerPrefab, flashlightHand.transform.position, Quaternion.identity);
            flameThrower.transform.SetParent(flashlightHand.transform, false);
            flameThrower.transform.position = flashlightHand.transform.position;

            //flames = GameObject.FindWithTag("Flames");
            //flames.SetActive(false);
        }
        else
        {
            InspectText.text = "I need the lighter first.";
            StartCoroutine(UseTextEnum());
        }

    }

    public void WhichUseItem(string s)
    {
        storedUseItemRef = s;
        itemUseBool = true;
    }

    public void TextUp()
    {
        StartCoroutine(UseTextEnum());
    }

    IEnumerator UseTextEnum()   //turns the text bubble on above the character's head when they use an item on another item.
    {
        InspectText.enabled = true;

        yield return new WaitForSeconds(3.0f);

        InspectText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "light")
        {
            Debug.Log("In Light");  //can be used later
        }
        if (collision.gameObject.tag == "KickZone")
        {
            k = collision.gameObject.GetComponentInParent<Kick>();
            //anim.SetBool("isKicking", true);
            
            kickBool = true;
        }
        if (collision.gameObject.tag == "Fall")
        {
            //Application.Quit();     //jump back to checkpoint instead
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "light")
        {
            Debug.Log("Exiting Light");
        }
        if (collision.gameObject.tag == "KickZone")
        {
           
            anim.SetBool("isKicking", false);
            kickBool = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            movementSpeed = 8f;
        }
        else
            movementSpeed = 5f;
    }

    public void Level1LightsOff()
    {
        _gm1.LightsOff();
        //_gm1.EnemeyOn();
    }

    public void LoadLevel2()
    {
        _fade.StartFadeOut("Level 2");
    }
    public void LoadLevel3()
    {
        _fade.StartFadeOut("Level_3");
    }
    public void LoadPR_1()
    {
        _fade.StartFadeOut("PR_1");
    }
    public void LoadTitle()
    {
        _fade.StartFadeOut("Title");
    }
    public void SceneAccessOn(string scene)
    {
        sceneAccessBool = true;
        sceneAccess = scene;
    }
    public void SceneAccessOff()
    {
        sceneAccessBool = false;
    }

    IEnumerator JumpSpeed()
    {
        movementSpeed = 10f;
        yield return new WaitForSeconds(0.4f);
        movementSpeed = 5f;
    }

    IEnumerator KickTime()
    {
        yield return new WaitForSeconds(1f);
        playerLock = false;
        anim.SetBool("isKicking", false);
    }





    private void HandleMovement(float horizontal)
    {
        if (horizontal != 0)
        {
            // play the run animation
            if (Input.GetKey(KeyCode.LeftShift) && stam > 0)
            {
                stamBool = false;
                myRigidbody.velocity = new Vector2(horizontal * movementSpeed + sprint, myRigidbody.velocity.y);
               
                anim.SetBool("isRunning", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", false);
                

                //play jump animation
                if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(JumpSpeed());
                   
                    anim.SetBool("isJumping", true);
                    anim.SetBool("isWalking ", false);
                    anim.SetBool("isRunning", false);
                    
                    myRigidbody.velocity = Vector2.up * jumpVelocity;
                }
               
            }
            // play the walk animation if the stamina of the player is less than 0
            else if (Input.GetKey(KeyCode.LeftShift) && stam < 0)
            {
                stamBool = false;
                myRigidbody.velocity = new Vector2(horizontal * movementSpeed + sprint, myRigidbody.velocity.y);
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift))
                {
                   
                    if (kickBool)
                    {
                        // play kick animation
                        k.KickFuncs();
                        //anim.SetBool("isKicking", true);


                    }
                }
                stamBool = true;
                myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); // move left 
            }
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit2d = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.down, BoxCollider.bounds.extents.y + extraHeight, layerMASK);
        return raycastHit2d.collider != null;
    }



    IEnumerator ItemCatalogue()
    {
        anim.SetBool("isUsing", true);                      //same thing for the animation that played when you used an item on an object. The new sprite from the artists only had a walk animation.
        switch (UseObj.name)   //switch statement to find the prefab of the item's namesake
        {
            case "Door":
                if (storedUseItemRef == "Key")
                {
                    InspectText.text = "It fits in the lock.";
                    StartCoroutine(UseTextEnum());
                    Destroy(GameObject.Find("KeyPrefab(Clone)"));    //storing the object would be more elegant
                    Destroy(UseObj);    //destroy the target object
                   // _gm3.AccessDoor2.SetActive(true);
                    tgm.Door1();
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
                else
                {
                    InspectText.text = "That doesn't work with that.";
                    StartCoroutine(UseTextEnum());
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
            case "Door2":
                if (storedUseItemRef == "Key2")
                {
                    Destroy(GameObject.Find("Key2Prefab(Clone)"));
                    Destroy(UseObj);
                    tgm.Door2();
                    itemUseBool = false;
                    itemlock = false;
                    _fade.StartFadeOut("Level 1");
                    break;
                }
                else
                {
                    InspectText.text = "That doesn't work with that.";
                    StartCoroutine(UseTextEnum());
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
            case "Door3":
                if (storedUseItemRef == "Key3")
                {
                    Destroy(GameObject.Find("Key3Prefab(Clone)"));
                    Destroy(UseObj);
                   
                    _gm1.AccessDoor.SetActive(true);
                    _gm1.DoorSFXon();
                   
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
                
                else
                {
                    InspectText.text = "That doesn't fit in the lock.";
                    StartCoroutine(UseTextEnum());
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
            case "DoortoLevel3":
                if (storedUseItemRef == "Key5")
                {
                    Destroy(GameObject.Find("Key5Prefab(Clone)"));
                    Destroy(UseObj);
                    _gm2.OpenLevel3();
                    InspectText.text = "Level_3";
                    
                    InspectText.text = "Door Open";
                    StartCoroutine(UseTextEnum());
                    //fade to level 3
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
               
                else
                {
                    InspectText.text = "That doesn't fit in the lock.";
                    StartCoroutine(UseTextEnum());
                    itemUseBool = false;
                    itemlock = false;
                    break;
                }
            


        }

        yield return new WaitForSeconds(0.2f);
        ShuffleItemsBack();
        yield return new WaitForSeconds(0.5f);
       // anim.SetBool("isUsing", false);
    }

    void ShuffleItemsBack()
    {
        StartCoroutine(ShufflingItemsEnum());
    }
    IEnumerator ShufflingItemsEnum()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 1; i < ItemSlots.Length - 1; i++)
        {
            if (ItemSlots[i].transform.childCount <= 0 && ItemSlots[i + 1].transform.childCount > 0)    //if the slot is empty and the one to the right is full
            {
                TempIteminInventory = ItemSlots[i + 1].transform.GetChild(0).gameObject;
                TempIteminInventory.transform.SetParent(ItemSlots[i], false);
                TempIteminInventory.transform.position = ItemSlots[i].position;
            }
        }
        yield return new WaitForSeconds(0.5f);
    }

    void Update()
    {
        Flip();

       
        if (!playerLock)
        {
            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    horizontal = -1f;
                    sprint = -5f;
                    FacingRight = true;  // flip the charcacter 
                    if (FacingRight)
                    {
                        if (!FootstepSound.isPlaying)
                        {
                            FootstepSound.Play();
                        }
                        
                    }
                    else
                    {
                        FootstepSound.Play();
                    }

                    anim.SetBool("isWalking", true);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isUsing", false);
                    
                }
                
                if (Input.GetKey(KeyCode.D))
                {
                    horizontal = 1f;
                    sprint = 5f;
                    FacingRight = false; // Flip the character 
                    if (FacingRight)
                    {
                        if (!FootstepSound.isPlaying)
                        {
                             FootstepSound.Play();
                        }
                        
                    }
                    else
                    {
                        FootstepSound.Play();
                    }

                    anim.SetBool("isWalking", true);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isUsing", false);
                }

                /*
                else
                {
                    //Stop everything
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isRunning", false);
                    //horizontal = 0f;
                }
                */
                
                if (Input.GetMouseButtonDown(1))
                {
                     if (kickBool)
                     {
                        // play kick animation
                        anim.SetBool("isKicking", true);
                        k.KickFuncs();


                     }
                     anim.SetBool("isKicking", true);
                     playerLock = true;
                     StartCoroutine(KickTime());
                     anim.SetBool("isWalking", false);
                     horizontal = 0f;
                     stamBool = true;
                     myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
                }
                
                

            }
            
            
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (kickBool)
                    {
                        // play kick animation
                        k.KickFuncs();
                        anim.Play("isKicking");
                    }
                }
                horizontal = 0f;
                stamBool = true;
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
                anim.SetBool("isWalking", false);       //this would turn on the idle animation, but there isn't one.
            }
            HandleMovement(horizontal);
        }
        

        if (sceneAccessBool)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _fade.StartFadeOut(sceneAccess);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.tag);
                if (itemlock == false)
                {
                    if (hit.collider.gameObject.tag == "item")
                    {
                        itemObj = hit.collider.gameObject;
                        if (Vector2.Distance(itemObj.transform.position, transform.position) < 4.0f)
                        {
                            //pick it up
                            StartCoroutine(Pickup());
                            itemlock = true;
                        }
                    }
                    if (hit.collider.gameObject.tag == "Interactable")
                    {
                        UseObj = hit.collider.gameObject;   //store the selected world object to use an item on
                    }
                    if (hit.collider.gameObject.tag == "Level1Lock")
                    {
                        _gm1.LockUiUp();
                        playerLock = true;
                    }
                    
                }

                if (itemUseBool)        //you click the use button on an item
                {
                    if (Input.GetMouseButtonDown(0))    //you click somewhere in the scene
                    {
                        //Getting the coordinates of the mouseposition in game
                        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        //store the location
                        target = new Vector2(mousePos.x, transform.position.y);

                        if (UseObj != null)     //A few lines above it detects if you clicked an interactible object and stores that in useObj. Here it goes into that.
                        {
                            if (itemlock == false)  //lock it from repeatedly entering
                            {
                                movingToObject = true;
                            }
                        }
                        else
                            itemUseBool = false;
                    }
                }
                if (movingToObject)
                {
                    anim.SetBool("isWalking", true);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(UseObj.transform.position.x, transform.position.y), Time.deltaTime * 5f);

                    if (Vector2.Distance(UseObj.transform.position, transform.position) < 5.0f)    //do the thing only when close to the object.
                    {
                        movingToObject = false;
                        StartCoroutine(ItemCatalogue());
                    }
                }
            }
        }

        if (flashlight != null)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - flashlight.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            flashlight.transform.rotation = Quaternion.Slerp(flashlight.transform.rotation, rotation, 5f * Time.deltaTime);
        }
        if (flameThrower != null)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - flameThrower.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            flameThrower.transform.rotation = Quaternion.Slerp(flameThrower.transform.rotation, rotation, 5f * Time.deltaTime);


            //if (Input.GetMouseButton(0))
            //{
            //    flames.SetActive(true);
            //}
            //if (!Input.GetMouseButton(0))
            //    flames.SetActive(false);
        }

        StaminaImg.value = stam;
        if (stamBool)
            if (stam <= 1)
                stam += 0.0007f;
        if (!stamBool)
            if (stam >= 0)
                stam -= 0.0015f;
        HPImg.value = hp;
        BatteryImg.value = batteryLife;
        if (flashlightDrain)
        {
            if (batteryLife > 0)
                batteryLife -= 0.00001f;
            else
            {
                batteryLife = 0;
                StowFlashlight();
            }
        }
    }
}