using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeMap.src.system
{
    class Vector3f
    {
        //-------------------------------------------------------------------------//

        public Vector3f() 
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        //-------------------------------------------------------------------------//

        public Vector3f( float x, float y, float z )
        {
            X = x;
            Y = y;
            Z = z;
        }

        //-------------------------------------------------------------------------//

        public Vector3f( Vector3f clone)
        {
            X = clone.X;
            Y = clone.Y;
            Z = clone.Z;
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator / (Vector3f Vector, float Value)
        {
            return new Vector3f( Vector.X / Value, Vector.Y / Value, Vector.Z / Value );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator / ( Vector3f Vector1, Vector3f Vector2 )
        {
            return new Vector3f( Vector1.X / Vector2.X, Vector1.Y / Vector2.Y, Vector1.Z / Vector2.Z );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator * ( Vector3f Vector, float Value )
        {
            return new Vector3f( Vector.X * Value, Vector.Y * Value, Vector.Z * Value );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator * ( Vector3f Vector1, Vector3f Vector2 )
        {
            return new Vector3f( Vector1.X * Vector2.X, Vector1.Y * Vector2.Y, Vector1.Z * Vector2.Z );
        }

        //-------------------------------------------------------------------------//

        public float X;
        public float Y;
        public float Z;
    }
}
