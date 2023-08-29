using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class LinearRotation : Rotation
    {
        private Vector3 rotationRate;

        public LinearRotation(float duration, float rotationRate)
        {
            this.rotationRate.Set(0, 0, rotationRate);
            SetDuration(duration);
        }

        public static LinearRotation New(float duration, float rotationRate) => new LinearRotation(duration, rotationRate);

        public override Vector3 GetEulerAngle()
        {
            return timer.Time() * rotationRate;
        }
    }
}
