using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class Rotation : Rotation3D
    {
        public abstract float GetAngle();

        public override Vector3 GetEulerAngles()
        {
            return new Vector3(0, 0, GetAngle());
        }
    }
}
