using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInterchange
{
    public Share<float> x;
    public Share<float> y;
    public Share<float> z;

    private Transform transform;

    public PositionInterchange(Transform transform)
    {
        this.transform = transform;
        x = new Share<float>();
        y = new Share<float>();
        z = new Share<float>();
    }

    public void UpdateTransform()
    {
        transform.localPosition.Set(x.value, y.value, z.value);
    }
}
