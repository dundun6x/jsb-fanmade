using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotionSequenceState
{
    Prepared, Acting, Stopped
}

public class MotionSequence
{
    private Queue<Motion> motions;
    private Motion curMotion = null;
    private MotionDataBlock dataBlock;
    private MotionSequenceState state;

    public void EnqueueMotion(Motion motion) { motions.Enqueue(motion); }
    public MotionSequenceState GetState() { return state; }
    public void SetState(MotionSequenceState p_state) { state = p_state; }
    
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
        curMotion.Act();
    }

    private void DequeueMotion()
    {
        curMotion = motions.Dequeue();
        curMotion.SetDataBlock(dataBlock);
        if (curMotion.GetState() == MotionState.Stopped)
        {
            curMotion = null;
            return;
        }
        curMotion.FollowState(MotionState.Acting);
    }

    public void FollowState(MotionSequenceState p_state)
    {
        switch (p_state)
        {
            case MotionSequenceState.Prepared:
                Prepare();
                break;
        }
    }

    private void Prepare()
    {
        dataBlock = new MotionDataBlock();
    }
}