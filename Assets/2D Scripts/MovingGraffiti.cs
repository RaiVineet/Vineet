using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGraffiti : MonoBehaviour
{
    SpriteRenderer sr;
    public bool start;
    public bool end;
    public Animator anim;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        start = false;
        end = false;
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadeInAndOut());
        }
    }

    IEnumerator FadeInAndOut()
    {
        yield return new WaitForSeconds(0.5f);
        start = true;
        yield return new WaitForSeconds(2);
        anim.SetBool("clueBool", true);
        yield return new WaitForSeconds(18);
        start = false;
        end = true;
        yield return new WaitForSeconds(15);
        end = false;
    }

    void Update()
    {
        if (start)
            sr.color = Color.Lerp(sr.color, Color.white, 0.9f * Time.deltaTime);
        if (end)
            sr.color = Color.Lerp(sr.color, Color.clear, 0.4f * Time.deltaTime);
    }
}

