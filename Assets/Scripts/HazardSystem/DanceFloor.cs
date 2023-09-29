using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.HazardSystem
{
    public class DanceFloor : Hazard
    {
        public GameObject prefab;

        public override void Generate()
        {
            if (go != null) return;
            go = Object.Instantiate(prefab);
        }

        public override bool IsHarmful() => true;
    }
}
