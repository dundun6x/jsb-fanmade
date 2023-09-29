using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class Coloring : SingleAnimation
    {
        protected ColoringController controller;

        public abstract Color GetColor();

        public override void RegisterToController()
        {
            AnimationControllerComponent component;
            if (!go.TryGetComponent(out component)) component = go.AddComponent<AnimationControllerComponent>();
            if (!component.Contains<ColoringController>())
            {
                SpriteRenderer renderer;
                if (!go.TryGetComponent(out renderer)) return;
                controller = new ColoringController(renderer);
                component.Add(controller);
            }
            else controller = component.Get<ColoringController>();
            controller.Register(this);
        }

        public override bool IsRegistered()
        {
            if (controller == null) return false;
            return controller.IsRegistered(this);
        }
    }
}
