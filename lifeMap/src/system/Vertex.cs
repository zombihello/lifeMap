using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeMap.src.system
{
    class Vertex
    {
        //-------------------------------------------------------------------------//

        public enum TypeVertex
        {
            RightTop,
            RightBottom,
            LeftBottom,
            LeftTop,
            Back_RightTop,
            Back_RightBottom,
            Back_LeftBottom,
            Back_LeftTop
        };

        //-------------------------------------------------------------------------//

        public Vertex() { }

        //-------------------------------------------------------------------------//

        public Vertex( Vector3f Position, TypeVertex type )
        {
            this.Position = Position;
            DefaultPosition = new Vector3f( Position.X, Position.Y, Position.Z );
            TexturePosition = new Vector3f( Position.X, Position.Y, Position.Z );
            typeVertex = type;
        }

        //-------------------------------------------------------------------------//

        public Vertex( float x, float y, float z, TypeVertex type )
        {
            Position = new Vector3f( x, y, z );
            DefaultPosition = new Vector3f( Position.X, Position.Y, Position.Z );
            TexturePosition = new Vector3f( Position.X, Position.Y, Position.Z );
            typeVertex = type;
        }

        //-------------------------------------------------------------------------//

        public void Move( Vector3f FactorMove )
        {
            Position += FactorMove;
            TexturePosition += FactorMove;
            DefaultPosition += FactorMove;
        }

        //-------------------------------------------------------------------------//

        public void Move( float FactorMove, Program.PlaneType planeType )
        {
            switch ( planeType )
            {
                case Program.PlaneType.X:
                    Position.X += FactorMove;
                    DefaultPosition.X += FactorMove;
                    TexturePosition.X += FactorMove;
                    break;

                case Program.PlaneType.Y:
                    Position.Y += FactorMove;
                    DefaultPosition.Y += FactorMove;
                    TexturePosition.Y += FactorMove;
                    break;

                case Program.PlaneType.Z:
                    Position.Z += FactorMove;
                    DefaultPosition.Z += FactorMove;
                    TexturePosition.Z += FactorMove;
                    break;
            }
        }

        //-------------------------------------------------------------------------//

        public Vector3f Position;
        public Vector3f DefaultPosition;
        public Vector3f TexturePosition;
        public TypeVertex typeVertex;
    }
}
