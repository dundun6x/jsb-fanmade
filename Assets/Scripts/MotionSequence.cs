using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotionSequenceState
{
    Idle, Prepared, Acting, Stopped
}

public class MotionSequence
{
    private Queue<Motion> motions;
    private Motion curMotion = null;
    private MotionSequenceState state;

    public void EnqueueMotion(Motion motion) { motions.Enqueue(motion); }
    public MotionSequenceState GetState() => state;
    public void SetState(MotionSequenceState state) { this.state = state; }
    
    public void Act()
    {
        if (curMotion == null)
        {
            if (motions.Count == 0) return;
            DequeueMotion();
        }
        if (curMotion.GetState() == MotionState.Stopped)
        {
            curMotion = null;
            return;
        }
        // curMotion.Act();
    }

    private void DequeueMotion()
    {
        curMotion = motions.Dequeue();
        // curMotion.SetDataBlock(dataBlock);
        if (curMotion.GetState() == MotionState.Stopped)
        {
            curMotion = null;
            return;
        }
        curMotion.SetState(MotionState.Acting);
    }

    public void FollowState(MotionSequenceState state)
    {
        switch (state)
        {
            case MotionSequenceState.Acting:
                // dataBlock = new MotionDataBlock();
                break;
        }
    }
}