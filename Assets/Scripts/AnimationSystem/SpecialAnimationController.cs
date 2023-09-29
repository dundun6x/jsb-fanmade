using System.Collections;
using System.Collections.Generic;
using JSB.AnimationSystem;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class SpecialAnimationController : AnimationController<Animation>
    {
        private static SpecialAnimationController inst;

        public static SpecialAnimationController GetInst()
        {
            if (inst == null){
                GameObject go = new("Special Animation Controller");
                inst = new SpecialAnimationController();
                var component = go.AddComponent<AnimationControllerComponent>();
                component.Add(inst);
            }
            return inst;
        }

        public override void ProcessAnimations()
        {
            foreach (var anim in anims)
            {
                if (anim is NoAnimation)
                {
                    AnimationState state = anim.State;
                    if (state == AnimationState.Finished)
                    {
                        Deregister(anim);
                    }
                    else if (state == AnimationState.Acting)
                    {
                        anim.UpdateState();
                    }
                }
            }
            HandleBuffers();
        }
    }
}
