using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using State = JSB.AnimationSystem.AnimationState;

namespace JSB.AnimationSystem
{
    public class SequentialGroupAnimation : GroupAnimation
    {
        public List<Animation> anims;
        public int currentAnimIndex = 0;
        public float nextTimePoint = 0;

        protected bool isTimeCorrectionEnabled = false;
        public bool IsTimeCorrectionEnabled { get => isTimeCorrectionEnabled; }

        public SequentialGroupAnimation() 
        { 
            anims = new(); 
        }
        public SequentialGroupAnimation(List<Animation> anims)
        {
            this.anims = new(anims);
        }

        public void Add(Animation anim) => anims.Add(anim);
        public Animation CurrentAnim() => anims[currentAnimIndex];
        public bool MoveNext() => ++currentAnimIndex < anims.Count;

        public void EnableTimeCorrection() => isTimeCorrectionEnabled = true;

        protected override void ToNewState()
        {
            foreach (var anim in anims)
            {
                anim.SetGameobject(go);
            }
            timer = new();
        }

        protected override void ToAgainState()
        {
            foreach (var anim in anims)
            {
                anim.residualRepetition = anim.repetition;
            }
            currentAnimIndex = 0;
            timer = new();
        }

        public override void CalcDuration()
        {
            duration = 0;
            foreach (var anim in anims)
            {
                duration += anim.duration;
            }
        }

        public override SequentialGroupAnimation Append(Animation anim)
        {
            Add(anim);
            return this;
        }
    }
}
        