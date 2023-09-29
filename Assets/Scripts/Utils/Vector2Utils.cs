using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.Utils
{
    public class Vector2Utils : StructUtils<Vector2>
    {
        public static Vector2Utils inst;

        public static Vector2Utils GetInst()
        {
            inst ??= new Vector2Utils();
            return inst;
        }

        public override Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return Vector2.Lerp(a, b, t);
        }

        public static Vector2 ToVector2(float speed, float angle)
        {
            angle = Mathf.Deg2Rad * angle;
            return new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed);
        }
    }
}
