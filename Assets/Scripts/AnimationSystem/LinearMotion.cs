using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSB.Utils;

namespace JSB.AnimationSystem
{
    public class LinearMotion : Motion
    {
        public Vector2 speed;

        public LinearMotion(float duration, Vector2 speed)
        {
            this.speed = speed;
            SetDuration(duration);
        }

        public LinearMotion(float duration, float speed, float angle)
        {
            this.speed = Vector2Utils.ToVector2(speed, angle);
            SetDuration(duration);
        }

        public override Vector2 GetDisplacement()
        {
            return timer.Time() * speed;
        }
    }
}
