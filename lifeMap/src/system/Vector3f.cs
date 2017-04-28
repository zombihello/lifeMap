using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeMap.src.system
{
    class Vector3f
    {
        public Vector3f() 
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3f( float x, float y, float z )
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X;
        public float Y;
        public float Z;
    }
}
