using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMotion : Motion
{
    private float duration;
    private Timer timer;

    public NoMotion(float duration)
    {
        this.duration = duration;
    }

    public override Vector3 GetDisplacement() => Vector3.zero;
    
    public override MotionState GetState()
    {
        if (timer.Time() > duration) SetState(MotionState.Stopped);
        return state;
    }

    public override void SetState(MotionState newState)
    {
        switch (state)
        {
        case MotionState.Acting:
            timer.Start();
            break;
        }
        this.state = newState;
    }
}