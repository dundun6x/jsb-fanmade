using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLinearMotion : Motion
{
    private float duration;
    private Timer timer;
    private Vector2 motionVector;

    public override Vector3 GetDisplacement()
    {
        return timer.Time() * motionVector;
    }

    public override MotionState GetState()
    {
        if (timer.Time() > duration) SetState(MotionState.Stopped);
        return state;
    }

    public override void SetState(MotionState state)
    {
        
    }
}
