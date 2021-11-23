using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Candle : MonoBehaviour
{
    Light2D flame;
    public float upper;
    public float lower;

    public bool low;
    public bool high;

    public float smooth;

    private void Awake()
    {
        flame = GetComponent<Light2D>();
        upper = Random.Range(14f, 20f);
        lower = Random.Range(5f, 8f);
        smooth = Random.Range(3f, 9f);
        low = true;
        high = false;
    }

    private void Update()
    {
        if (low) 
            flame.intensity = Mathf.Lerp(flame.intensity, lower, Time.deltaTime * smooth);
        if (high)
            flame.intensity = Mathf.Lerp(flame.intensity, upper, Time.deltaTime * smooth);

        if (flame.intensity <= lower + 0.5f)
        {
            low = false;
            high = true;
            smooth = Random.Range(3f, 9f);
        }
        if (flame.intensity >= upper - 0.5f)
        {
            low = true;
            high = false;
            smooth = Random.Range(3f, 9f);
        }
    }
}
