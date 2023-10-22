using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class LinearRotation : Rotation
    {
        public float speed; // degrees per second

        public LinearRotation(float duration, float speed)
        {
            this.speed = speed;
            SetDuration(duration);
        }

        public override float GetAngle()
        {
            return timer.Time() * speed;
        }
    }
}
