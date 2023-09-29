using System;
using System.Collections.Generic;

using JSB.Utils;

namespace JSB.AnimationSystem
{
    public class FromToRotation : Rotation
    {
        public FromToCore<float> core;

        public FromToRotation(float from, float to)
        {
            core = new(FloatUtils.GetInst(), from, to);
        }

        public FromToRotation(float from, float to, FromToCurve curve)
        {
            core = new(FloatUtils.GetInst(), from, to, curve);
        }

        public override float GetAngle()
        {
            return core.GetValue(timer.Time() / duration);
        }
    }
}
