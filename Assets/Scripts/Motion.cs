using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public abstract class Motion : Animation
    {
        protected MotionController controller;

        public abstract Vector2 GetDisplacement();

        public override void Register()
        {
            if (!go.TryGetComponent(out controller))
            {
                controller = go.AddComponent<MotionController>();
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
