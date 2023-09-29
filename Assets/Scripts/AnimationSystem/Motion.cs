using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class Motion : Motion3D
    {
        public abstract Vector2 GetDisplacement();

        public override Vector3 GetDisplacement3D()
        {
            return GetDisplacement();
        }
    }
}
