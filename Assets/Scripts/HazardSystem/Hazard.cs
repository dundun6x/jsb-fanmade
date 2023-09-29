using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.HazardSystem
{
    public abstract class Hazard
    {
        protected GameObject go;

        public abstract void Generate();
        public abstract bool IsHarmful();
    }
}
