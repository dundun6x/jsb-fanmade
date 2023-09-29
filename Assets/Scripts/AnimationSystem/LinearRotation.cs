using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class LinearRotation : Rotation
    {
        public float rate;

        public LinearRotation(float duration, float rate)
        {
            this.rate = rate;
            SetDuration(duration);
        }

        public override float GetAngle()
        {
            return timer.Time() * rate;
        }
    }
}
