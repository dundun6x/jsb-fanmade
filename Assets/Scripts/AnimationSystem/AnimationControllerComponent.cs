using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class AnimationControllerComponent : MonoBehaviour
    {
        private Dictionary<Type, IAnimationController> controllers = new();

        public void Add<T>(T controller) where T : IAnimationController
        {
            controllers.Add(typeof(T), controller);
        }

        public bool Contains<T>() where T : IAnimationController

            => controllers.ContainsKey(typeof(T));

        public T Get<T>() where T : IAnimationController

            => (T)controllers[typeof(T)];

        private void Update()
        {
            foreach (var controller in controllers)
                controller.Value.ProcessAnimations();
        }
    }
}
