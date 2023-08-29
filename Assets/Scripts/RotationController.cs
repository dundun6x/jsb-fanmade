using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class RotationController : AnimationController<Rotation>
    {
        private void Update()
        {
            foreach (var rotation in anims)
            {
                AnimationState state = rotation.GetState();
                if (state == AnimationState.Finished)
                    Unregister(rotation);
                else if(state == AnimationState.Acting)
                {
                    transform.localEulerAngles = rotation.GetEulerAngle();
                    rotation.UpdateState();
                }
            }
        }
    }
}
