using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

using lifeMap.src.system;

namespace lifeMap.src.brushes
{
    class BrushBox : BasicBrush
    {
        //-------------------------------------------------------------------------//

        public BrushBox() { }

        //-------------------------------------------------------------------------//

        public BrushBox( SaveBrush brush )
        {
            InitBrush( brush, PrimitivesType.Cube );
            ColorBrush = new Color( 0, 127, 127 );
            DefaultColorBrush = ColorBrush;
        }

        //-------------------------------------------------------------------------//

        public override void Create( Vector3f StartPosition, Vector3f EndPosition )
        {
            InitBrush( StartPosition, EndPosition, PrimitivesType.Cube, ManagerTexture.SelectTexture );
            brushType = BasicBrush.BrushType.Brush;
            ColorBrush = new Color( 0, 127, 127 );
            DefaultColorBrush = ColorBrush;

            // Front
            AddVertex( 0, 0, 0, Vertex.TypeVertex.LeftBottom ); // 0
            AddVertex( Size.X, 0, 0, Vertex.TypeVertex.RightBottom ); // 1
            AddVertex( Size.X, Size.Y, 0, Vertex.TypeVertex.RightTop ); // 2
            AddVertex( 0, Size.Y, 0, Vertex.TypeVertex.LeftTop ); // 3

            // Back
            AddVertex( 0, 0, Size.Z, Vertex.TypeVertex.Back_LeftBottom ); // 4
            AddVertex( Size.X, 0, Size.Z, Vertex.TypeVertex.Back_RightBottom ); // 5
            AddVertex( Size.X, Size.Y, Size.Z, Vertex.TypeVertex.Back_RightTop ); // 6
            AddVertex( 0, Size.Y, Size.Z, Vertex.TypeVertex.Back_LeftTop ); // 7

            GenerateTextureCoords();
            GenerateNormals();
            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//
    }
}
