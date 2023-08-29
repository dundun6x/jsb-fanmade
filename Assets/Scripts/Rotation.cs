using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public abstract class Rotation : Animation
    {
        protected RotationController controller;

        public abstract Vector3 GetEulerAngle();

        public override void Register()
        {
            if (!go.TryGetComponent(out controller))
            {
                controller = go.AddComponent<RotationController>();
            }
            controller.Register(this);
        }

        public override bool IsRegistered()
        {
            if (controller == null) return false;
            return controller.IsRegistered(this);
        }
    }
}
