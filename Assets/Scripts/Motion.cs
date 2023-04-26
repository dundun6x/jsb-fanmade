using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotionState
{
    Queuing, Acting, Stopped
}

public abstract class Motion
{
    protected MotionDataBlock dataBlock;
    protected MotionState state;

    public abstract void Act();
    public abstract void SetState(MotionState p_state);
    public abstract MotionState GetState();

    public void SetDataBlock(MotionDataBlock p_dataBlock)
    {
        dataBlock = p_dataBlock;
    }
}
