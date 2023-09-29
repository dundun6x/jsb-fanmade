using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.HazardSystem
{
    public class HazardComponent : MonoBehaviour
    {
        private Hazard hazard;

        public void SetHazard(Hazard hazard) => this.hazard = hazard;
        public bool IsHarmful() => hazard.IsHarmful();
    }
}
