using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class ColoringController : SingleAnimationController<Coloring>
    {
        protected SpriteRenderer renderer;

        public ColoringController(SpriteRenderer renderer) => this.renderer = renderer;

        public override void ProcessActingAnimations(List<Coloring> actingAnims)
        {
            renderer.color = actingAnims.Last().GetColor();
        }
    }
}
