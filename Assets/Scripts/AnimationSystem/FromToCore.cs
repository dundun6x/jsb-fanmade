using System;
using System.Collections.Generic;

using JSB.Utils;

namespace JSB.AnimationSystem
{
    public class FromToCore<TValue> where TValue : struct
    {
        public StructUtils<TValue> utils;

        public TValue from;
        public TValue to;
        public FromToCurve curve;

        public FromToCore(StructUtils<TValue> utils, TValue from, TValue to)
        {
            this.utils = utils;
            this.from = from;
            this.to = to;
            curve = new(FromToCurveType.Linear);
        }

        public FromToCore(StructUtils<TValue> utils, TValue from, TValue to, FromToCurve curve)
        {
            this.from = from;
            this.to = to;
            this.curve = curve;
        }

        public TValue GetValue(float t)
        {
            return utils.Lerp(from, to, curve.Evaluate(t));
        }

    }
}
