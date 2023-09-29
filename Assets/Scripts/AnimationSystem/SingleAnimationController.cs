using System;
using System.Collections.Generic;

namespace JSB.AnimationSystem
{
    public abstract class SingleAnimationController<TAnim> : AnimationController<TAnim> where TAnim : Animation
    {
        public override void ProcessAnimations()
        {
            List<TAnim> actingAnims = new();
            foreach (var anim in anims)
            {
                AnimationState state = anim.State;
                if (state == AnimationState.Finished)
                {
                    --anim.residualRepetition;
                    FinishOrRepeat(anim);
                }
                else if (state == AnimationState.Acting)
                {
                    actingAnims.Add(anim);
                    anim.UpdateState();
                }
            }
            if (actingAnims.Count > 0) ProcessActingAnimations(actingAnims);
            HandleBuffers();
        }

        public abstract void ProcessActingAnimations(List<TAnim> actingAnims);
    }
}
