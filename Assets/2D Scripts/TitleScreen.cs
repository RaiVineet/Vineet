using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button newGame;
    public Button exit;

    public Image img;

    public GameObject p;
    public PlayerControl pc;

    void Start()
    {
        StartCoroutine(FadeIn());
        img.canvasRenderer.SetAlpha(1.0f);
    }

    IEnumerator FadeIn()
    {
        img.CrossFadeAlpha(0, 1.5f, false);

        yield return new WaitForSeconds(1.5f);
        img.gameObject.SetActive(false);
    }

    IEnumerator FadeOut(string scene)
    {
        img.gameObject.SetActive(true);
        img.canvasRenderer.SetAlpha(0.0f);
        img.CrossFadeAlpha(1, 1.5f, false);
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    public void NewGame()
    {
        FadeTo("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
