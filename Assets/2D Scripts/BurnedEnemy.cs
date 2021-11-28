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

    public bool inFlames;
    public bool flameSwitch;

    public GameObject p;
    public PlayerControl pc;
    public GameObject _GM2;
    public GM2 _gm2;
    public GameObject _GM3;
    public GM3 _gm3;

    private void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        inFlames = false;
        flameSwitch = false;

        moveSpeed = 5;

        if (p == null)
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
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pc.TakeDamage();
        }
    }

    public void FlipSpriteCheck()
    {
        if (transform.position.x < p.transform.position.x)
        {
            mySprite.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flames")
        {
            inFlames = true;
        }
    }

    IEnumerator Dying()
    {
        dyingFlames.SetActive(true);
        //play burn animation with particles
        yield return new WaitForSeconds(2f);
        _gm2.normalLight.gameObject.SetActive(true);
        _gm2.redLight.gameObject.SetActive(false);

        _gm2.timer = Random.Range(20f, 120f);
        _gm2.timerGate = true;
        Destroy(gameObject);
    }

    void Update()
    {
        if (!inFlames)
        {
            if (!flameSwitch)
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(p.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);

            //run speed if he sees player? Testing needed on this as if he can see us, we can see him, so he would always be running to us

            //what to do if he passes under the player?
        }

        if (inFlames)
        {
            flameSwitch = true;
            StartCoroutine(Dying());
        }
    }
}
