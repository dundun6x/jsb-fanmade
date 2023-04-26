using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMotion : Motion
{
    public float duration;

    private Timer timer;

    public NoMotion(float p_duration)
    {
        state = MotionState.Queuing;
        duration = p_duration;
    }

    public override void Act(){}
    
    public override MotionState GetState()
    {
        UpdateState();
        return state;
    }

    public void UpdateState()
    {
        if (timer.Time() > duration) state = MotionState.Stopped;
    }

    public override void SetState(MotionState p_state)
    {
        switch (p_state)
        {
            case MotionState.Acting:
                Start();
                break;
        }
        state = p_state;
    }

    private void Start()
    {
        timer.Start();
    }
}