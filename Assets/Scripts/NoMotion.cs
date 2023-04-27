using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMotion : Motion
{
    public float duration;

    private Timer timer;

    public NoMotion(float p_duration)
    {
        state = MotionState.Idle;
        duration = p_duration;
    }

    public override void Act(){}
    
    public override MotionState GetState()
    {
        // Update state
        if (timer.Time() > duration) state = MotionState.Stopped;
        return state;
    }

    public override void FollowState(MotionState p_state)
    {
        switch (p_state)
        {
            case MotionState.Acting:
                timer.Start();
                break;
        }
    }
}