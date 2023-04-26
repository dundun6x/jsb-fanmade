using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Motion
{
    public float frontWaitTime;
    public float duration;
    public float endWaitTime;

    private MotionDataBlock dataBlock;

    public abstract void Start();
    public abstract void Act();
    public abstract void End();

    public void SetDataBlock(MotionDataBlock p_dataBlock)
    {
        dataBlock = p_dataBlock;
    }
}
