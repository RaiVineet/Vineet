using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFade : MonoBehaviour
{
    public Color s;

    private void Start()
    {
        s = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine(FadeUp());
            StartCoroutine(FadeDown());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine(FadeDown());
            StartCoroutine(FadeUp());
        }
    }

    IEnumerator FadeDown()
    {
        while (s.a > 0)
        {
            s.a -= 0.001f;
            yield return new WaitForSeconds(0.001f);
            this.GetComponent<SpriteRenderer>().color = s;
        }
        
        yield return null;
    }

    IEnumerator FadeUp()
    {
        while (s.a < 1)
        {
            s.a += 0.001f;
            yield return new WaitForSeconds(0.001f);
            this.GetComponent<SpriteRenderer>().color = s;
        }
        
        yield return null;
    }
}
