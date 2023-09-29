using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSB.AnimationSystem;

namespace JSB.HazardSystem
{
    public class Barrage : Hazard
    {
        public GameObject prefab;
        public Vector2 position;
        public LinearMotion motion;
        public LinearRotation rotation;

        public Barrage(GameObject prefab, Vector2 position, Vector2 move, float rotate)
        {
            this.prefab = prefab;
            this.position = position;
            motion = new LinearMotion(15, move);
            rotation = new LinearRotation(15, rotate);
        }

        public Barrage(GameObject prefab, Vector2 position, float speed, float angle, float rotate)
        {
            this.prefab = prefab;
            this.position = position;
            motion = new LinearMotion(15, speed, angle);
            rotation = new LinearRotation(15, rotate);
        }

        public override void Generate()
        {
            if (go != null) return;
            go = Object.Instantiate(prefab);
            prefab.transform.localPosition = position;
            motion.ActOn(go);
            rotation.ActOn(go);
        }

        public override bool IsHarmful() => true;
    }
}