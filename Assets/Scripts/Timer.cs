using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float startTime;

    public void Start() => startTime = UnityEngine.Time.time;
    public float Time() => UnityEngine.Time.time - startTime;
}
