using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class Scaling : SingleAnimation
    {
        protected ScalingController controller;

        public abstract Vector2 GetScale();

        public override void RegisterToController()
        {
            AnimationControllerComponent component;
            if (!go.TryGetComponent(out component)) component = go.AddComponent<AnimationControllerComponent>();
            if (!component.Contains<ScalingController>())
            {
                controller = new ScalingController(go.transform);
                component.Add(controller);
            }
            else controller = component.Get<ScalingController>();
            controller.Register(this);
        }

        public override bool IsRegistered()
        {
            if (controller == null) return false;
            return controller.IsRegistered(this);
        }
    }
}
