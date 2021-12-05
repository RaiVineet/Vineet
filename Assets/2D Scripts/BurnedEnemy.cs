using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BurnedEnemy : MonoBehaviour
{
    public float moveSpeed;  
    public bool moveRight;
    public float rightMost;
    public float leftMost;
    private SpriteRenderer mySprite;
    public GameObject dyingFlames;
    public Animator anim;

    public bool inFlames;
    public bool flameSwitch;
    private bool FacingRight;
    
    public GameObject p;
    public PlayerControl pc;
    public GameObject _GM2;
    public GM2 _gm2;
    public GameObject _GM3;
    public GM3 _gm3;

    //public Light2D redLight;
    //public Light2D normalLight;

    public GameObject BurnSoundSFXobj;
    public AudioSource BurnSoundSFX;

    private void Start()
    {
        if (p == null)
        {
            p = GameObject.Find("Player");
            pc = p.GetComponent<PlayerControl>();
            Debug.Log("Got the Enemy player");
        }
        mySprite = GetComponentInChildren<SpriteRenderer>();
        inFlames = false;
        flameSwitch = false;
        
        moveSpeed = 5f;

        //redLight.gameObject.SetActive(false);
        
        _GM2 = GameObject.Find("Level2GameManager");
        if (_GM2 != null)
            _gm2 = _GM2.gameObject.GetComponent<GM2>();

        _GM3 = GameObject.Find("Level3GameManager");
        if (_GM3 != null)
            _gm3 = _GM3.gameObject.GetComponent<GM3>();
        dyingFlames.SetActive(false);

        BurnSoundSFX = BurnSoundSFXobj.GetComponent<AudioSource>();
    }
    //if the enemy collide with object tag name Player then take damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //play the enemy killing the player animation 
            
            pc.TakeDamage(); // take damamge, load the scene 
        }
    }
    // check the player must flip towards the player
    public void FlipSpriteCheck()
    {
        if (transform.position.x < p.transform.position.x)
        {
            anim.SetBool("chase", true);

            //mySprite.flipX = true // for the burned enemy who have the sprite sheet 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flames")
        {
            //play the Retreat animation ( get expose to fire) as just for the little time before the retreat animation ( ran away animation )
           
            inFlames = true;
            anim.SetBool("retreat", true);
        }
    }

    IEnumerator Dying()
    {
        dyingFlames.SetActive(true);
       
        yield return new WaitForSeconds(2f);
        
        Destroy(gameObject);
    }

    void Update()
    {
        FlipSpriteCheck(); // check the flip of the enemy
        if (inFlames == true)
        {
            anim.SetBool("retreat", true);
            
            StartCoroutine(Dying());
        }
        anim.SetBool("chase", true);
        if (!inFlames)
        {
            
           
            if (!flameSwitch)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(p.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
            }
             
           
            //run speed if he sees player? Testing needed on this as if he can see us, we can see him, so he would always be running to us

            //what to do if he passes under the player?
        }

        if (inFlames)
        {
          
            flameSwitch = true;
            anim.SetBool("retreat", true);
            BurnSoundSFX.Play();
            StartCoroutine(Dying());
        }
    }
}
//_gm2.timer = Random.Range(20f, 120f);
//_gm2.timerGate = true;

//redLight.gameObject.SetActive(false);
//normalLight.gameObject.SetActive(true);
