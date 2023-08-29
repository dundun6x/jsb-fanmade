using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class SequentialAnimGroup : AnimationGroup
    {
        protected Queue<Animation> anims;
        
        public SequentialAnimGroup() 
        { 
            anims = new(); 
        }
        public SequentialAnimGroup(List<Animation> anims)
        {
            this.anims = new(anims);
        }

        public void Add(Animation anim) => anims.Enqueue(anim);
        public int Count() => anims.Count;
        public Animation Peek() => anims.Peek();
        public void Dequeue() => anims.Dequeue();

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
        