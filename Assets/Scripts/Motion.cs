using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotionState
{
    Idle, Acting, Stopped
}

public abstract class Motion
{
    protected MotionDataBlock dataBlock;
    protected MotionState state;

    public abstract void Act();
    public virtual MotionState GetState() { return state; }
    public virtual void SetState(MotionState p_state) { state = p_state; }
    public abstract void FollowState(MotionState p_state);
    public void SetDataBlock(MotionDataBlock p_dataBlock) { dataBlock = p_dataBlock; }
}
