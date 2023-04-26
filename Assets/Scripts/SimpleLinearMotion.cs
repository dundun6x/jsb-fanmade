using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLinearMotion : Motion
{
    public float moveSpeed;

    public override void Act()
    {
        
    }

    public override MotionState GetState()
    {
        UpdateState();
        return state;
    }

    public void UpdateState()
    {

    }

    public override void SetState(MotionState p_state)
    {
        state = p_state;
    }
}
