using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class SetRotation : Rotation
    {
        private float angle;

        public SetRotation(float angle){ this.angle = angle; }

        public override float GetAngle() => angle;
    }
}
