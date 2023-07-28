using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotionState
{
    Idle, Acting, Paused, Stopped
}

public abstract class Motion
{
    protected MotionState state = MotionState.Idle;

    public abstract Vector3 GetDisplacement();
    public abstract MotionState GetState();
    public abstract void SetState(MotionState newState);
}
