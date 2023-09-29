using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class Motion3D : SingleAnimation
    {
        protected MotionController controller;

        public abstract Vector3 GetDisplacement3D();

        public override void RegisterToController()
        {
            AnimationControllerComponent component;
            if (!go.TryGetComponent(out component)) component = go.AddComponent<AnimationControllerComponent>();
            if (!component.Contains<MotionController>())
            {
                controller = new MotionController(go.transform);
                component.Add(controller);
            }
            else controller = component.Get<MotionController>();
            controller.Register(this);
        }

        public override bool IsRegistered()
        {
            if (controller == null) return false;
            return controller.IsRegistered(this);
        }
    }
}