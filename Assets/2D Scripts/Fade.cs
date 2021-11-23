using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image fade;
    private static Fade instance;

    public GameObject p;
    public PlayerControl pc;

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

    void Start()
    {
        if (p == null)
        {
            p = GameObject.FindGameObjectWithTag("Player");
            pc = p.GetComponent<PlayerControl>();
        }
        StartCoroutine(FadeIn());
        fade.canvasRenderer.SetAlpha(1.0f);
    }

    IEnumerator FadeIn()
    {
        fade.CrossFadeAlpha(0, 1.5f, false);

        yield return new WaitForSeconds(1.5f);
    }

    public void StartFadeOut(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeOut(string scene)
    {
        pc.playerLock = true;
        pc.anim.SetBool("isWalking", false);
        fade.gameObject.SetActive(true);
        fade.canvasRenderer.SetAlpha(0.0f);
        fade.CrossFadeAlpha(1, 1.5f, false);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(0.1f);

        fade.CrossFadeAlpha(0, 1.5f, false);

        yield return new WaitForSeconds(0.5f);
        pc.FindOnScene();
        pc.playerLock = false;
    }
}
