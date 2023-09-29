using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSB.Utils;

namespace JSB.AnimationSystem
{
    public class FromToScaling : Scaling
    {
        public FromToCore<Vector2> core;

        public FromToScaling(Vector2 from, Vector2 to)
        {
            core = new(Vector2Utils.GetInst(), from, to);
        }

        public FromToScaling(Vector2 from, Vector2 to, FromToCurve curve)
        {
            core = new(Vector2Utils.GetInst(), from, to, curve);
        }

        public override Vector2 GetScale()
        {
            return core.GetValue(timer.Time() / duration);
        }
    }
}
