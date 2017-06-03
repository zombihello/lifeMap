using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.system;

namespace lifeMap.src.brushes
{
    class Entity : BasicBrush
    {
        //-------------------------------------------------------------------------//

        public void Create( Vector3f Position )
        {
            brushType = BasicBrush.BrushType.Entity;
            this.Position = Program.Align( Position, Viewport.fSize );
            Size = new Vector3f( 16, 32, 16 );
            SelectSize = new Vector3f( Size / 2 );
            ColorBrush = DefaultColorBrush = new Color( 0, 0.5f, 0.5f );

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

            InitIdVertex( PrimitivesType.Cube );
            GenerateTextureCoords();           
            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        public static ListEntity listEntity;
    }
}
