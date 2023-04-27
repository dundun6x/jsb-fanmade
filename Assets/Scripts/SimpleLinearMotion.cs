using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLinearMotion : Motion
{
    public Vector2 motionVector;

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

    public override void FollowState(MotionState p_state)
    {
        
    }
}
