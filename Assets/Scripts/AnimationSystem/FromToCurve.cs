using System;
using System.Collections;
using UnityEngine;

using CType = JSB.AnimationSystem.FromToCurveType;

namespace JSB.AnimationSystem
{
    public enum FromToCurveType
    {
        Linear,
        InQuad, OutQuad, InOutQuad,
        InCubic, OutCubic, InOutCubic,
        InSine, OutSine, InOutSine
    }

    public class FromToCurve
    {
        public CType type;
        public FromToCurve(CType type) => this.type = type;

        const float PiOver2 = Mathf.PI / 2;

        public float Evaluate(float t)
        {
            t = Mathf.Clamp01(t);
            return type switch
            {
                CType.Linear => t,
                CType.InQuad => t * t,
                CType.OutQuad => t * (2 - t),
                CType.InOutQuad => t < 0.5 ? t * t : t * (2 - t),
                CType.InCubic => t * t * t,
                CType.OutCubic => (--t) * t * t + 1,
                CType.InOutCubic => t < 0.5 ? t * t * t : (--t) * t * t + 1,
                CType.InSine => -Mathf.Cos(t * PiOver2) + 1,
                CType.OutSine => Mathf.Sin(t * PiOver2),
                CType.InOutSine => t < 0.5 ? -Mathf.Cos(t * PiOver2) + 1 : Mathf.Sin(t * PiOver2),
                _ => 0
            };
        }
    }
}
