using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDataBlock
{
    private Transform transform;
    public Vector3 position
    {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    public void AttachTo(Transform p_transform)
    {
        transform = p_transform;
    }
}
