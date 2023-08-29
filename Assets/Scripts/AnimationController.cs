using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public abstract class AnimationController<T> : MonoBehaviour where T : Animation
    {
        public HashSet<T> anims = new();

        public void Register(T anim)
        {
            anims.Add(anim);
        }

        public void Unregister(T anim)
        {
            anims.Remove(anim);
        }

        public bool IsRegistered(T anim)
        {
            return anims.Contains(anim);
        }
    }
}
