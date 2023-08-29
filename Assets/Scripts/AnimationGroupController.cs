using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class AnimationGroupController : AnimationController<AnimationGroup>
    {
        private static AnimationGroupController inst;

        public static AnimationGroupController GetInst()
        {
            if (inst == null){
                GameObject go = new("Animation Group Controller");
                inst = go.AddComponent<AnimationGroupController>();
            }
            return inst;
        }

        private List<AnimationGroup> groupRemoval = new();

        private void Update() 
        {
            foreach (var group in anims)
            {
                if (group is SequentialAnimGroup)
                {
                    ProcessSequentialAnimGroup((SequentialAnimGroup)group);
                } 
                else if (group is ParallelAnimGroup)
                {
                    ProcessParallelAnimGroup((ParallelAnimGroup)group);
                }
            }
            foreach (var group in groupRemoval)
            {
                anims.Remove(group);
            }
            groupRemoval = new();
        }

        private void ProcessSequentialAnimGroup(SequentialAnimGroup group)
        {
            Animation cur = group.Peek();
            
            // 这个时候归具体的 AnimationController 管
            if (cur.IsRegistered()) return;

            if (cur.GetState() == AnimationState.Finished)
            {
                group.Dequeue();
                if (group.Count() == 0) anims.Remove(group);
                return;
            }
            cur.Register();
            cur.SetState(AnimationState.Acting);
        }

        private void ProcessParallelAnimGroup(ParallelAnimGroup group)
        {
            HashSet<Animation>.Enumerator e = group.GetEnumerator();
            List<Animation> removal = new();
            while (e.MoveNext())
            {
                var cur = e.Current;
                if (cur.IsRegistered()) return;

                if (cur.GetState() == AnimationState.Finished)
                {
                    if (group.Count() == 0) groupRemoval.Add(group);
                    removal.Add(cur);
                    return;
                }
                cur.Register();
                cur.SetState(AnimationState.Acting);
            };
            foreach (var anim in removal)
            {
                group.Remove(anim);
            }
        }
    }
}
