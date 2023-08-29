using System.Collections;
using System.Collections.Generic;
using JSB;
using UnityEngine;

namespace JSB
{
    public class SpecialAnimController : AnimationController<Animation>
    {
        private static SpecialAnimController inst;

        public static SpecialAnimController GetInst()
        {
            if (inst == null){
                GameObject go = new("Special Animation Controller");
                inst = go.AddComponent<SpecialAnimController>();
            }
            return inst;
        }

        private void Update()
        {
            foreach (var anim in anims)
            {
                if (anim is NoAnimation)
                {
                    AnimationState state = anim.GetState();
                    if (state == AnimationState.Finished)
                        Unregister(anim);
                    else if(state == AnimationState.Acting)
                    {
                        anim.UpdateState();
                    }
                }
            }
        }
    }
}
