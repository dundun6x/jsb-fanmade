using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB{
    public class LinearMotion : Motion
    {
        private Vector2 motionVector;

        public LinearMotion(float duration, Vector2 motionVector)
        {
            this.motionVector = motionVector;
            SetDuration(duration);
        }

        public static LinearMotion New(float duration, Vector2 motionVector) => new LinearMotion(duration, motionVector);

        public override Vector2 GetDisplacement()
        {
            return timer.Time() * motionVector;
        }
    }
}
