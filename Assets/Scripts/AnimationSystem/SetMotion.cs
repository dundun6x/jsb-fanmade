using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.AnimationSystem
{
    public class SetMotion : Motion
    {
        private Vector2 position;
    
        public SetMotion(Vector2 position){ this.position = position; }
    
        public override Vector2 GetDisplacement() => position;
    }
}
