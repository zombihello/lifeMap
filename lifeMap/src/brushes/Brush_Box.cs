using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.system;

namespace lifeMap.src.brushes
{
    class Brush_Box : BasicBrush
    {
        //-------------------------------------------------------------------------//

        public override void Create( Vector3f StartPosition, Vector3f EndPosition )
        {
            InitBrush( StartPosition, EndPosition );

            Mesh.Add( new Vector3f( StartPosition.X, StartPosition.Y, StartPosition.Z ) );
            Mesh.Add( new Vector3f( StartPosition.X + ( EndPosition.X - StartPosition.X ), StartPosition.Y, StartPosition.Z ) );
            Mesh.Add( new Vector3f( StartPosition.X + ( EndPosition.X - StartPosition.X ), StartPosition.Y + ( EndPosition.Y - StartPosition.Y ), StartPosition.Z ) );
            Mesh.Add( new Vector3f( StartPosition.X, StartPosition.Y + ( EndPosition.Y - StartPosition.Y ), StartPosition.Z ) );

            Mesh.Add( new Vector3f( StartPosition.X, StartPosition.Y, StartPosition.Z ) );
            Mesh.Add( new Vector3f( StartPosition.X, -StartPosition.Y + ( EndPosition.Y + StartPosition.Y ), StartPosition.Z ) );
            Mesh.Add( new Vector3f( StartPosition.X + ( EndPosition.X - StartPosition.X ), StartPosition.Y, StartPosition.Z ) );
            Mesh.Add( new Vector3f( StartPosition.X + ( EndPosition.X - StartPosition.X ), -StartPosition.Y + ( EndPosition.Y + StartPosition.Y ), StartPosition.Z ) );
        }

        //-------------------------------------------------------------------------//
    }
}
