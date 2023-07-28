using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float startTimePoint = 0;
    private float cumulativeTime = 0;
    private bool paused = true;

    public void Start()
    {
        if (!paused) return;
        startTimePoint = UnityEngine.Time.time;
        paused = false;
    }

    public void Pause()
    {
        if (paused) return;
        cumulativeTime += UnityEngine.Time.time - startTimePoint;
        paused = true;
    }

    public float Time() => cumulativeTime + UnityEngine.Time.time - startTimePoint;
}
