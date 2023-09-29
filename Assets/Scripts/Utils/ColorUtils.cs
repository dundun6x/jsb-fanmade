using System;
using System.Collections.Generic;

using UnityEngine;

namespace JSB.Utils
{
    public class ColorUtils : StructUtils<Color>
    {
        public static ColorUtils inst;

        public static ColorUtils GetInst()
        {
            inst ??= new ColorUtils();
            return inst;
        }

        public override Color Lerp(Color a, Color b, float t)
        {
            return Color.Lerp(a, b, t);
        }
    }
}
