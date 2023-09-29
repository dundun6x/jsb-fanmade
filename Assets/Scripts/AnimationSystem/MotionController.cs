using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class MotionController : SingleAnimationController<Motion3D>
    {
        protected Transform transform;
        protected Vector3 reference;

        public MotionController(Transform transform)
        {
            this.transform = transform;
            reference = transform.localPosition;
        }

        public override void ProcessActingAnimations(List<Motion3D> actingAnims)
        {
            transform.localPosition = reference + actingAnims.Last().GetDisplacement3D();
        }
    }
}
