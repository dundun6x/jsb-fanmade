using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class NoAnimation : SingleAnimation
    {
        public NoAnimation(float duration) => SetDuration(duration);
        
        public override void RegisterToController()
        {
            SpecialAnimationController.GetInst().Register(this);
        }

        public override bool IsRegistered()
        {
            return SpecialAnimationController.GetInst().IsRegistered(this);
        }

        protected override void ToNewState()
        {
            duration *= repetition;
            residualRepetition = repetition = 1;
            timer = new();
        }
    }
}
