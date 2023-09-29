using System;
using System.Collections.Generic;

namespace JSB.Utils
{
    public abstract class StructUtils<TValue> where TValue : struct
    {
        public abstract TValue Lerp(TValue a, TValue b, float t);
    }
}
