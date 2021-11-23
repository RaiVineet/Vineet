using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;
    public float rightMost;
    public float leftMost;
    private SpriteRenderer mySprite;

    public GameObject RightEye;
    public GameObject LeftEye;

    public bool inLight;
    public bool lightSwitch;

    public GameObject p;
    public PlayerControl pc;

    private void Start()
    {
        mySprite = GetComponentInChildren<SpriteRenderer>();
        inLight = false;
        lightSwitch = true;
        if (moveRight)
            LeftEye.SetActive(false);
        else
            RightEye.SetActive(false);

        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (lightSwitch)
        {
            if (collision.gameObject.tag == "light")
            {
                StartCoroutine(Flee());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pc.TakeDamage();
        }
    }

    IEnumerator Flee()
    {
        inLight = true;
        lightSwitch = false;
        yield return new WaitForSeconds(3);
        inLight = false;
        lightSwitch = true;
    }

    void Update()
    {
        if (!inLight)
        {
            if (transform.position.x >= rightMost)
            {
                moveRight = false;
                RightEye.SetActive(false);
                LeftEye.SetActive(true);
                mySprite.flipX = false;
            }

            if (transform.position.x <= leftMost)
            {
                moveRight = true;
                RightEye.SetActive(true);
                LeftEye.SetActive(false);
                mySprite.flipX = true;
            }


            if (moveRight)
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (inLight)
        {
            if (moveRight)
                transform.position = new Vector2(transform.position.x - (moveSpeed * 2) * Time.deltaTime, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x + (moveSpeed * 2) * Time.deltaTime, transform.position.y);
        }
    }
}
