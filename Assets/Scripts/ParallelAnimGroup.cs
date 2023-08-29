using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class ParallelAnimGroup : AnimationGroup
    {
        protected HashSet<Animation> anims;
        
        public ParallelAnimGroup() => anims = new();
        public ParallelAnimGroup(List<Animation> anims)
        {
            this.anims = new(anims);
        }

        public void Add(Animation anim) => anims.Add(anim);
        public int Count() => anims.Count;
        public HashSet<Animation>.Enumerator GetEnumerator() => anims.GetEnumerator();
        public void Remove(Animation anim) => anims.Remove(anim);

        public override void SetGameobject(GameObject go)
        {
            base.SetGameobject(go);
            foreach (var anim in anims)
            {
                anim.SetGameobject(go);
            }
        }

        public override void CalcDuration()
        {
            duration = 0;
            foreach (var anim in anims)
            {
                duration += anim.GetDuration();
            }
        }
    }
}
        