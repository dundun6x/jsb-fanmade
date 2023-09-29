using System;
using System.Collections.Generic;
using UnityEngine;

using JSB.Utils;

namespace JSB.AnimationSystem
{
    public class FromToMotion : Motion
    {
        public FromToCore<Vector2> core;

        public FromToMotion(Vector2 from, Vector2 to)
        {
            core = new(Vector2Utils.GetInst(), from, to);
        }

        public FromToMotion(Vector2 from, Vector2 to, FromToCurve curve)
        {
            core = new(Vector2Utils.GetInst(), from, to, curve);
        }

        public override Vector2 GetDisplacement()
        {
            return core.GetValue(timer.Time() / duration);
        }
    }
}
