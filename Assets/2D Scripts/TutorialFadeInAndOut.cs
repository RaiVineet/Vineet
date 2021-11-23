using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFadeInAndOut : MonoBehaviour
{
    SpriteRenderer sr;
    public bool start;
    public bool end;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        start = false;
        end = false;
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
        yield return new WaitForSeconds(7);
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
