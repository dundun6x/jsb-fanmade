using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class RotationController : SingleAnimationController<Rotation3D>
    {
        protected Transform transform;
        protected Vector3 reference;

        public RotationController(Transform transform)
        {
            this.transform = transform;
            reference = transform.localEulerAngles;
        }

        public override void ProcessActingAnimations(List<Rotation3D> actingAnims)
        {
            transform.localEulerAngles = reference + actingAnims.Last().GetEulerAngles();
        }
    }
}
