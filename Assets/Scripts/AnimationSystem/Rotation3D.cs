using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class Rotation3D : SingleAnimation
    {
        protected RotationController controller;

        public abstract Vector3 GetEulerAngles();

        public override void RegisterToController()
        {
            AnimationControllerComponent component;
            if (!go.TryGetComponent(out component)) component = go.AddComponent<AnimationControllerComponent>();
            if (!component.Contains<RotationController>())
            {
                controller = new RotationController(go.transform);
                component.Add(controller);
            }
            else controller = component.Get<RotationController>();
            controller.Register(this);
        }

        public override bool IsRegistered()
        {
            if (controller == null) return false;
            return controller.IsRegistered(this);
        }
    }
}
