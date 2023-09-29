using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSB.HazardSystem
{
    public class BarrageFactory
    {
        public static GameObject squarePrefab;

        protected Func<Vector2> positionGen;
        protected Func<float> rotateGen;
        protected Func<Vector2> moveGen;
        protected Func<float> speedGen;
        protected Func<float> angleGen;

        public BarrageFactory SetPositionGen(Func<Vector2> positionGen) { this.positionGen = positionGen; return this; }
        public BarrageFactory SetRotateGen(Func<float> rotateGen) { this.rotateGen = rotateGen; return this; }
        public BarrageFactory SetMoveGen(Func<Vector2> moveGen) { this.moveGen = moveGen; return this; }
        public BarrageFactory SetSpeedGen(Func<float> speedGen) { this.speedGen = speedGen; return this; }
        public BarrageFactory SetAngleGen(Func<float> angleGen) { this.angleGen = angleGen; return this; }

        public Barrage CreateSquare()
        {
            if (moveGen != null) return new Barrage(squarePrefab, positionGen(), moveGen(), rotateGen());
            return new Barrage(squarePrefab, positionGen(), speedGen(), angleGen(), rotateGen());
        }
    }
}
