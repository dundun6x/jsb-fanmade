using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class NoAnimation : Animation
    {
        public NoAnimation(float duration) => this.duration = duration;
        public static NoAnimation New(float duration) => new NoAnimation(duration);
        
        public override void Register()
        {
            SpecialAnimController.GetInst().Register(this);
        }

        public override bool IsRegistered()
        {
            return SpecialAnimController.GetInst().IsRegistered(this);
        }
    }
}
