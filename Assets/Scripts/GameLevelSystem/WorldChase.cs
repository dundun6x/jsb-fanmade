using System.Collections;
using UnityEngine;

using JSB.AnimationSystem;
using JSB.HazardSystem;

namespace JSB.GameLevelSystem
{
    public class WorldChase : FreeGameLevel
    {
        private BarrageFactory bf;

        public override void Init()
        {
            bf = new BarrageFactory();
            bf.SetPositionGen(() => new Vector2(5, Random.Range(-5f, 5f)));
            bf.SetSpeedGen(() => 10f);
            bf.SetAngleGen(() => Random.Range(0f, 360f));
            bf.SetRotateGen(() => 240f);
        }

        public override IEnumerator Perform()
        {
            for (int i = 0; i < 50; ++i)
            {
                bf.CreateSquare().Generate();
                yield return Wait(0.2f);
            }
        }
    }
}
