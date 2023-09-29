using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.GameLevelSystem
{
    public abstract class FreeGameLevel
    {
        protected Timer timer = new();
        protected float waitTo = 0;

        public abstract void Init();
        public abstract IEnumerator Perform();

        public YieldInstruction Wait(float time)
        {
            waitTo += time;
            return new WaitForSeconds(waitTo - timer.Time());
        }
    }
}
