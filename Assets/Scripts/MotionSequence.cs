using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSequence
{
    private Queue<Motion> motions;
    private Motion curMotion = null;
    private MotionDataBlock dataBlock;
    private bool started;

    public void Start()
    {
        started = true;
    }

    private void Update()
    {
        if (!started) return;
        if (curMotion == null)
        curMotion.Act();
        if (curMotion.GetState() == MotionState.Stopped) curMotion = null;
    }
}