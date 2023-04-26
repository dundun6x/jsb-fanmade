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
        return state;
    }
}
