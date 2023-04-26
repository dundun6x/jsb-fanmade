using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSequence
{
    private Queue<Motion> motions;
    private Motion curMotion = null;
    private MotionDataBlock dataBlock;

    private Timer timer;
    private float timePoint = 0;

    public void Activate()
    {
        if (motions.Count == 0) return;
        curMotion = motions.Dequeue();
        timer.Start();
    }

    private void Update()
    {
        if (curMotion == null) return;
        curMotion.Act();
        if (curMotion.GetState() == MotionState.Stopped) ;
    }
}