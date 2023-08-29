using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JSB
{
    public class TestScript : MonoBehaviour
    {
        public GameObject go;
        
        private void Start()
        {
            ParallelAnimGroup g1 = new();
            g1.Add(LinearRotation.New(5, 240));
            g1.Add(LinearMotion.New(5, new Vector2(1, 1)));

            SequentialAnimGroup g2 = new();
            g2.Add(NoAnimation.New(5));
            g2.Add(g1);

            g2.ActOn(go);
        }
    }
}
