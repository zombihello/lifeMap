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
        public override void Create( Vector3f StartPosition, Vector3f EndPosition )
        {
            InitBrush( StartPosition, EndPosition );
            ColorBrush = new Color( 0, 0.5f, 0.5f );
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

            //----------------------------------------------
            // Id Вершин / Тип рисовния - Линии (Для 2D)
            //---------------------------------------------

            List<int> vId_Lines = new List<int>
            {
                0, 1, 2, 3,
                0, 3, 1, 2,

                4, 5, 6, 7,
                4, 7, 5, 6,

                0, 4, 3, 7,
                0, 3, 4, 7,

                1, 5, 2, 6,
                1, 2, 5, 6,

                3, 2, 7, 6,
                3, 7, 2, 6,

                0, 1, 4, 5,
                0, 4, 1, 5
            };

            //-----------------------------------------------------
            // Id Вершин / Тип рисовния - Треугольники (Для 3D)
            //-----------------------------------------------------

            List<int> vId_Triangles = new List<int>
            {
                7, 3, 4,
                3, 0, 4,

                2, 6, 1,
                6, 5, 1,

                7, 6, 3,
                6, 2, 3,

                0, 1, 4,
                1, 5, 4,

                6, 4, 5,
                6, 7, 4,

                0, 2, 1,
                0, 3, 2
            };

            InitIdVertex( vId_Lines, vId_Triangles );
            ToGloablCoords();

            TextureBrush.LoadTexture( "1.jpg" );
        }

        //-------------------------------------------------------------------------//
    }
}
