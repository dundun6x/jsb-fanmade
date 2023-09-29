using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public abstract class AnimationController<TAnim> : IAnimationController where TAnim : Animation
    {
        protected HashSet<TAnim> anims = new();
        protected List<TAnim> registerBuffer = new();
        protected List<TAnim> deregisterBuffer = new();

        public void Register(TAnim anim) => registerBuffer.Add(anim);
        public void Deregister(TAnim anim) => deregisterBuffer.Add(anim);

        public bool IsRegistered(TAnim anim)
        {
            return anims.Contains(anim);
            // return (anims.Contains(anim) || registerBuffer.Contains(anim))
            //     && !deregisterBuffer.Contains(anim);
        }

        public void HandleBuffers()
        {
            foreach (TAnim anim in registerBuffer) anims.Add(anim);
            foreach (TAnim anim in deregisterBuffer) anims.Remove(anim);
            registerBuffer = new();
            deregisterBuffer = new();
        }

        public abstract void ProcessAnimations();

        public void Finish(TAnim anim)
        {
            anim.SetState(AnimationState.Finished);
            Deregister(anim);
        }

        public void Repeat(TAnim anim)
        {
            anim.SetState(AnimationState.Again);
            anim.SetState(AnimationState.Acting);
        }

        public void FinishOrRepeat(TAnim anim)
        {
            if (anim.residualRepetition <= 0) Finish(anim);
            else Repeat(anim);
        }
    }
}
