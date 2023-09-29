using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class GroupAnimationController : AnimationController<GroupAnimation>
    {
        private static GroupAnimationController inst;

        public static GroupAnimationController GetInst()
        {
            if (inst == null){
                GameObject go = new("Animation Group Controller");
                inst = new GroupAnimationController();
                var component = go.AddComponent<AnimationControllerComponent>();
                component.Add(inst);
            }
            return inst;
        }

        public override void ProcessAnimations() 
        {
            foreach (var group in anims)
            {
                if (group is SequentialGroupAnimation sGroup)
                {
                    ProcessSequentialAnimGroup(sGroup);
                } 
                else if (group is ParallelGroupAnimation pGroup)
                {
                    ProcessParallelAnimGroup(pGroup);
                }
            }
            HandleBuffers();
        }

        private void ProcessSequentialAnimGroup(SequentialGroupAnimation group)
        {
            Animation cur = group.CurrentAnim();
            
            // cur 正在被注册的 AnimationController 处理，不需要操作
            if (cur.IsRegistered()) return;

            // cur 未在处理，要么是结束了，要么是没开始
            if (cur.State == AnimationState.Finished)
            {
                if (group.MoveNext() == false)
                {
                    --group.residualRepetition;
                    FinishOrRepeat(group);
                    return;
                }
                if (group.IsTimeCorrectionEnabled)
                {
                    cur = group.CurrentAnim();
                    group.nextTimePoint += cur.duration * cur.residualRepetition;
                    cur.duration = (group.nextTimePoint - group.GetTime()) / cur.residualRepetition;
                }
                return;
            }

            cur.Act();

            if (group.IsTimeCorrectionEnabled)
            {
                group.nextTimePoint = cur.duration * cur.residualRepetition;
            }
        }

        private void ProcessParallelAnimGroup(ParallelGroupAnimation group)
        {
            List<Animation> removal = new();
            foreach (var cur in group.anims)
            {
                if (cur.IsRegistered()) continue;

                if (cur.State == AnimationState.Finished)
                {
                    removal.Add(cur);
                    if (group.anims.Count == 1) Finish(group);
                    continue;
                }

                cur.Act();
            }
            foreach (var anim in removal)
            {
                group.Remove(anim);
            }
        }
    }
}
