using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.Utils
{
    public class FloatUtils : StructUtils<float>
    {
        public static FloatUtils inst;

        public static FloatUtils GetInst()
        {
            inst ??= new FloatUtils();
            return inst;
        }

        public override float Lerp(float a, float b, float t)
        {
            return Mathf.Lerp(a, b, t);
        }
    }
}
