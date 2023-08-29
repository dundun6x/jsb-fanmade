using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public abstract class AnimationGroup : Animation
    {
        public override void Register()
        {
            AnimationGroupController.GetInst().Register(this);
        }

        public override bool IsRegistered()
        {
            return AnimationGroupController.GetInst().IsRegistered(this);
        }
        
        public abstract void CalcDuration();
    }
}