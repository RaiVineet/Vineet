using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject BurnSoundSFXobj;
    public AudioSource BurnSoundSFX;

    private void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        inFlames = false;
        flameSwitch = false;
        
        moveSpeed = 7f;

        //if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        _GM2 = GameObject.Find("Level2GameManager");
        if (_GM2 != null)
            _gm2 = _GM2.gameObject.GetComponent<GM2>();

        _GM3 = GameObject.Find("Level3GameManager");
        if (_GM3 != null)
            _gm3 = _GM3.gameObject.GetComponent<GM3>();
        dyingFlames.SetActive(false);

        BurnSoundSFX = BurnSoundSFXobj.GetComponent<AudioSource>();
    }
    //if the enemy 
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

           // anim.Play("(Mal (Burned Enemy)(Chase Animation)");
            anim.SetBool("chase", true);

            mySprite.flipX = true;
          
           
            
            //if (FacingRight)
            //{

               
            //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180.0f, transform.localEulerAngles.z);

            //}
            //else
            //{
               
            //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0.0f, transform.localEulerAngles.z);
            //}
            
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
        _gm2.normalLight.gameObject.SetActive(true);
        _gm2.redLight.gameObject.SetActive(false);

        _gm2.timer = Random.Range(20f, 120f);
        _gm2.timerGate = true;
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
