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

        public Vector3f( string values )
        {
            string[] tmpValues = values.Split( ' ' );
            X = Y = Z = 0;

            for ( int i = 0; i < tmpValues.Length; i++ )
                switch ( i )
                {
                    case 0:
                        X = float.Parse( tmpValues[ i ] );
                        break;

                    case 1:
                        Y = float.Parse( tmpValues[ i ] );
                        break;

                    case 2:
                        Z = float.Parse( tmpValues[ i ] );
                        return;
                }
        }

        //-------------------------------------------------------------------------//

        public Vector3f( Vector3f clone )
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

        public static Vector3f operator -( Vector3f Vector1, Vector3f Vector2 )
        {
            return new Vector3f( Vector2.X - Vector1.X, Vector2.Y - Vector1.Y, Vector2.Z - Vector1.Z );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator -( Vector3f Vector1, float value )
        {
            return new Vector3f( Vector1.X - value, Vector1.Y - value, Vector1.Z - value );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator +( Vector3f Vector1, Vector3f Vector2 )
        {
            return new Vector3f( Vector1.X + Vector2.X, Vector1.Y + Vector2.Y, Vector1.Z + Vector2.Z );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f operator +( Vector3f Vector1, float value )
        {
            return new Vector3f( Vector1.X + value, Vector1.Y + value, Vector1.Z + value );
        }

        //-------------------------------------------------------------------------//

        public void Normalize()
        {
            float size = ( float )Math.Sqrt( Math.Pow( X, 2 ) + Math.Pow( Y, 2 ) + Math.Pow( Z, 2 ) );

            if ( size == 0 )
                size = 1;

            X /= size;
            Y /= size;
            Z /= size;
        }
        //-------------------------------------------------------------------------//

        public static float DotProduct( Vector3f Vector1, Vector3f Vector2 )
        {
            return ( float ) Vector1.X * Vector2.X + Vector1.Y * Vector2.Y + Vector1.Z * Vector2.Z;
        }

        //-------------------------------------------------------------------------//

        public static Vector3f CrossProduct( Vector3f Vector1, Vector3f Vector2 )
        {
            return new Vector3f(
                Vector1.Y * Vector2.Z - Vector1.Z * Vector2.Y,
                Vector1.Z * Vector2.X - Vector1.X * Vector2.Z,
                Vector1.X * Vector2.Y - Vector1.Y * Vector2.X);
        }

        //-------------------------------------------------------------------------//

        public float X;
        public float Y;
        public float Z;
    }
}
