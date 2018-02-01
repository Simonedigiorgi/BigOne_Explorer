using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Glow : MonoBehaviour 
{
    Light light;
    public float middleIntensity;
    public float variation;   
    public float frequency;

    void Start () 
    {
        light = GetComponent<Light>();
    }

    void Update () 
    {
        float x = Time.time * frequency;
        x = x - Mathf.Floor(x); // normalized value to 0..1
        light.intensity = variation * Mathf.Sin(2 * Mathf.PI * x) + middleIntensity;
    }
}