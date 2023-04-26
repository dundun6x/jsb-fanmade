using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSequence
{
    private Queue<Motion> motions;
    private Motion curMotion;

    
    private Timer timer;
    private float timePoint = 0;

    public void Initiate()
    {
        if (motions.Count == 0) return;
        timer.Start();
    }

    private void Update()
    {
        curMotion.Act();
        if (curMotion.GetState() == MotionState.Stopped) ;
    }
}