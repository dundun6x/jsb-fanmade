using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class ScalingController : SingleAnimationController<Scaling>
    {
        protected Transform transform;

        public ScalingController(Transform transform) => this.transform = transform;

        public override void ProcessActingAnimations(List<Scaling> actingAnims)
        {
            transform.localScale = actingAnims.Last().GetScale();
        }
    }
}

