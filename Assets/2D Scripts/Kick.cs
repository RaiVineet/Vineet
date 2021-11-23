using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public bool chairBool;

    private Animator anim;

    private AudioSource scrape;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        scrape = GetComponent<AudioSource>();
    }

    public void ChairFunc()
    {
        if (chairBool)
        {
            StartCoroutine(ChairEnum());
        }
    }
    IEnumerator ChairEnum()
    {
        anim.SetBool("ChairAnimBool", true);
        scrape.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void KickFuncs()
    {
        ChairFunc();
    }
}
