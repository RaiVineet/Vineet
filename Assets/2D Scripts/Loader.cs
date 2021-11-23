using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public Image img;

    public GameObject p;
    public PlayerControl pc;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator Load()
    {
        img.gameObject.SetActive(true);
        img.canvasRenderer.SetAlpha(0.0f);
        img.CrossFadeAlpha(1, 1.5f, false);
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Tutorial");

        yield return new WaitForSeconds(0.0001f);
        p = GameObject.FindGameObjectWithTag("Player");
        pc = p.GetComponent<PlayerControl>();

        pc.Respawn();

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    public void LoadSave()
    {
        StartCoroutine(Load());
    }
}
