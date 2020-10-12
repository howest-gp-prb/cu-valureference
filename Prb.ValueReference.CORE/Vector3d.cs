using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.ValueReference.CORE
{
    public struct Vector3d
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector3d(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

}
