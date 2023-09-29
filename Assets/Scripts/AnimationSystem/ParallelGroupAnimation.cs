using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using State = JSB.AnimationSystem.AnimationState;

namespace JSB.AnimationSystem
{
    public class ParallelGroupAnimation : GroupAnimation
    {
        public HashSet<Animation> anims;
        
        public ParallelGroupAnimation() => anims = new();
        public ParallelGroupAnimation(List<Animation> anims)
        {
            this.anims = new(anims);
        }

        public void Add(Animation anim) => anims.Add(anim);
        public void Remove(Animation anim) => anims.Remove(anim);

        protected override void ToNewState()
        {
            foreach (var anim in anims)
            {
                anim.SetGameobject(go).SetRepetition(anim.repetition * repetition);
            }
            residualRepetition = repetition = 1;
            timer = new();
        }

        protected override void ToAgainState()
        {
            foreach (var anim in anims)
            {
                anim.residualRepetition = anim.repetition;
            }
            timer = new();
        }

        public override void CalcDuration()
        {
            duration = 0;
            foreach (var anim in anims)
            {
                duration = Mathf.Max(duration, anim.duration);
            }
        }
    }
}
        