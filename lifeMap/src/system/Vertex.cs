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

        public Vertex( Vector3f Position, TypeVertex type )
        {
            this.Position = Position;
            typeVertex = type;
        }

        //-------------------------------------------------------------------------//

        public Vertex( float x, float y, float z, TypeVertex type )
        {
            Position = new Vector3f( x, y, z );
            typeVertex = type;
        }

        //-------------------------------------------------------------------------//

        public Vector3f Position = new Vector3f();
        public TypeVertex typeVertex;
    }
}
