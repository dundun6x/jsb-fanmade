using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class GroupAnimation : Animation
    {
        public override void RegisterToController()
        {
            GroupAnimationController.GetInst().Register(this);
        }

        public override bool IsRegistered()
        {
            return GroupAnimationController.GetInst().IsRegistered(this);
        }
        
        public abstract void CalcDuration();
    }
}