using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSB.AnimationSystem;

namespace JSB
{
    public class TestScript : MonoBehaviour
    {
        public GameObject go;
        
        private void Start()
        {
            ParallelGroupAnimation g1 = new();

            g1.Add(new LinearMotion(5, new Vector2(1, 1)).SetRepetition(2));

            SequentialGroupAnimation g2 = new();

            g2.Add(new NoAnimation(5));
            g2.Add(g1);
            g2.EnableTimeCorrection();

            g2.ActOn(go);
        }
    }
}
