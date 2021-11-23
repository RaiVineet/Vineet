using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashlightFlicker : MonoBehaviour
{
    Light2D torch;

    public float timer;

    public bool timerGate;

    private void Awake()
    {
        torch = GetComponent<Light2D>();
        timer = Random.Range(2f, 15f);
        timerGate = true;
    }

    IEnumerator Flicker()
    {
        yield return new WaitForSeconds(timer);

        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = 1f;
        yield return new WaitForSeconds(0.1f);
        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = Random.Range(0f, 0.9f);
        yield return new WaitForSeconds(0.1f);
        torch.intensity = 1f;

        timer = Random.Range(2f, 15f);
        timerGate = true;
    }

    private void Update()
    {
        if (timerGate)
        {
            timerGate = false;
            StartCoroutine(Flicker());
        }
    }
}
