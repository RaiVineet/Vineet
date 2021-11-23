using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWalk : MonoBehaviour
{
    SpriteRenderer sr;
    public bool start;
    public bool end;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        StartCoroutine(FadeInAndOut());
        start = false;
        end = false;
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
