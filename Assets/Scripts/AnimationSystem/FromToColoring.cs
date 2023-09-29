using System;
using System.Collections.Generic;
using UnityEngine;

using JSB.Utils;

namespace JSB.AnimationSystem
{
    public class FromToColoring : Coloring
    {
        public FromToCore<Color> core;

        public FromToColoring(Color from, Color to)
        {
            core = new(ColorUtils.GetInst(), from, to);
        }

        public FromToColoring(Color from, Color to, FromToCurve curve)
        {
            core = new(ColorUtils.GetInst(), from, to, curve);
        }

        public override Color GetColor()
        {
            return core.GetValue(timer.Time() / duration);
        }
    }
}
