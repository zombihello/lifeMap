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
    class BrushBox : BasicBrush
    {
        //-------------------------------------------------------------------------//
        public override void Create( Vector3f StartPosition, Vector3f EndPosition )
        {
            InitBrush( StartPosition, EndPosition );

            // Front
            AddVertex( StartPosition.X, StartPosition.Y, StartPosition.Z ); // 0
            AddVertex( StartPosition.X + Size.X, StartPosition.Y, StartPosition.Z ); // 1
            AddVertex( StartPosition.X + Size.X, StartPosition.Y + Viewport.fSize, StartPosition.Z ); // 2
            AddVertex( StartPosition.X, StartPosition.Y + Viewport.fSize, StartPosition.Z ); // 3

            // Back
            AddVertex( StartPosition.X, StartPosition.Y, StartPosition.Z + Size.Z ); // 4
            AddVertex( StartPosition.X + Size.X, StartPosition.Y, StartPosition.Z + Size.Z ); // 5
            AddVertex( StartPosition.X + Size.X, StartPosition.Y + Viewport.fSize, StartPosition.Z + Size.Z ); // 6
            AddVertex( StartPosition.X, StartPosition.Y + Viewport.fSize, StartPosition.Z + Size.Z ); // 7

            // Front
            AddIdVertex( 0 ); AddIdVertex( 1 ); AddIdVertex( 2 ); AddIdVertex( 3 );
            AddIdVertex( 0 ); AddIdVertex( 3 ); AddIdVertex( 1 ); AddIdVertex( 2 );

            // Back
            AddIdVertex( 4 ); AddIdVertex( 5 ); AddIdVertex( 6 ); AddIdVertex( 7 );
            AddIdVertex( 4 ); AddIdVertex( 7 ); AddIdVertex( 5 ); AddIdVertex( 6 );

            // Left
            AddIdVertex( 0 ); AddIdVertex( 4 ); AddIdVertex( 3 ); AddIdVertex( 7 );
            AddIdVertex( 0 ); AddIdVertex( 3 ); AddIdVertex( 4 ); AddIdVertex( 7 );

            // Right
            AddIdVertex( 1 ); AddIdVertex( 5 ); AddIdVertex( 2 ); AddIdVertex( 6 );
            AddIdVertex( 1 ); AddIdVertex( 2 ); AddIdVertex( 5 ); AddIdVertex( 6 );

            // Top
            AddIdVertex( 3 ); AddIdVertex( 2 ); AddIdVertex( 7 ); AddIdVertex( 6 );
            AddIdVertex( 3 ); AddIdVertex( 7 ); AddIdVertex( 2 ); AddIdVertex( 6 );

            // Bottom
            AddIdVertex( 0 ); AddIdVertex( 1 ); AddIdVertex( 4 ); AddIdVertex( 5 );
            AddIdVertex( 0 ); AddIdVertex( 4 ); AddIdVertex( 1 ); AddIdVertex( 5 );
        }

        //-------------------------------------------------------------------------//
    }
}
