using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class MotionController : AnimationController<Motion>
    {
        private void Update()
        {
            foreach (var motion in anims)
            {
                AnimationState state = motion.GetState();
                if (state == AnimationState.Finished)
                    Unregister(motion);
                else if(state == AnimationState.Acting)
                {
                    transform.localPosition = motion.GetDisplacement();
                    motion.UpdateState();
                }
            }
        }
    }
}
