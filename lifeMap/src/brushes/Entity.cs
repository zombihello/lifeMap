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
    class Entity
    {
        //-------------------------------------------------------------------------//

        public void Create( Vector3f Position )
        {
            InitEntity( Position );
            ColorEntity = new Color( 0, 0.5f, 0.5f );
            DefaultColorEntity = ColorEntity;

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

            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        public void Render( Viewport.TypeViewport typeViewport )
        {
            RenderCenterEntity( typeViewport );

            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glColor3f( ColorEntity.R, ColorEntity.G, ColorEntity.B );

                for ( int i = 0; i < mIdVertex_Lines.Count; i++ )
                {
                    int id = mIdVertex_Lines[ i ];
                    Gl.glVertex3f( mGlobalVertex[ id ].X, mGlobalVertex[ id ].Y, mGlobalVertex[ id ].Z );
                }
            }
            else
            {
                 Gl.glBegin( Gl.GL_TRIANGLES );
                 Gl.glColor3f( ColorEntity.R, ColorEntity.G, ColorEntity.B );

                for ( int i = 0; i < mIdVertex_Triangles.Count; i++ )
                {
                    int id = mIdVertex_Triangles[ i ];
                    Gl.glVertex3f( mGlobalVertex[ id ].X, mGlobalVertex[ id ].Y, mGlobalVertex[ id ].Z );
                }
            }

            Gl.glEnd();
        }

        //-------------------------------------------------------------------------//

        private void RenderCenterEntity( Viewport.TypeViewport typeViewport )
        {
            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                float factorSize = 4;

                Gl.glBegin( Gl.GL_LINES );
                Gl.glColor3f( ColorEntity.R, ColorEntity.G, ColorEntity.B );

                if ( Viewport.TmpViewport.FactorZoom > 0 )
                    factorSize *= Viewport.TmpViewport.FactorZoom;
                else
                    factorSize /= Viewport.TmpViewport.FactorZoom;

                Gl.glVertex3f( CenterEntity.X - factorSize, CenterEntity.Y - factorSize, CenterEntity.Z - factorSize );
                Gl.glVertex3f( CenterEntity.X + factorSize, CenterEntity.Y + factorSize, CenterEntity.Z + factorSize );

                if ( typeViewport != Viewport.TypeViewport.Front_2D_yz )
                {
                    Gl.glVertex3f( CenterEntity.X + factorSize, CenterEntity.Y - factorSize, CenterEntity.Z - factorSize );
                    Gl.glVertex3f( CenterEntity.X - factorSize, CenterEntity.Y + factorSize, CenterEntity.Z + factorSize );
                }
                else
                {
                    Gl.glVertex3f( CenterEntity.X + factorSize, CenterEntity.Y - factorSize, CenterEntity.Z + factorSize );
                    Gl.glVertex3f( CenterEntity.X - factorSize, CenterEntity.Y + factorSize, CenterEntity.Z - factorSize );
                }

                Gl.glEnd();
            }
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( Vector3f PositionVertex, Vertex.TypeVertex type )
        {
            mLocalVertex.Add( new Vertex( PositionVertex, type ) );
            mGlobalVertex.Add( PositionVertex );
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( float x, float y, float z, Vertex.TypeVertex type )
        {
            mLocalVertex.Add( new Vertex( x, y, z, type ) );
            mGlobalVertex.Add( new Vector3f( x, y, z ) );
        }

        //-------------------------------------------------------------------------//

        protected void InitEntity( Vector3f Position )
        {
            this.Position = Program.Align( Position, Viewport.fSize );

            SelectSize = new Vector3f( Size / 2 );
            InitIdVertex();
        }

        //-------------------------------------------------------------------------//

        protected void ToGloablCoords()
        {
            for ( int i = 0; i < mLocalVertex.Count; i++ )
                mGlobalVertex[ i ] = mLocalVertex[ i ].Position + Position;

            CenterEntity = Position + Size / 2;
        }

        //-------------------------------------------------------------------------//

        private void UpdateSelectPoints()
        {
            Vector3f MaxVertex = new Vector3f();
            Vector3f MinVertex = new Vector3f();

            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                if ( i == 0 )
                {
                    MaxVertex = new Vector3f( mLocalVertex[ i ].Position );
                    MinVertex = new Vector3f( mLocalVertex[ i ].Position );
                }
                else
                {

                    if ( mLocalVertex[ i ].Position.Y > MaxVertex.Y )
                        MaxVertex.Y = mLocalVertex[ i ].Position.Y;

                    if ( mLocalVertex[ i ].Position.X > MaxVertex.X )
                        MaxVertex.X = mLocalVertex[ i ].Position.X;

                    if ( mLocalVertex[ i ].Position.Z > MaxVertex.Z )
                        MaxVertex.Z = mLocalVertex[ i ].Position.Z;

                    if ( mLocalVertex[ i ].Position.Y < MinVertex.Y )
                        MinVertex.Y = mLocalVertex[ i ].Position.Y;

                    if ( mLocalVertex[ i ].Position.X < MinVertex.X )
                        MinVertex.X = mLocalVertex[ i ].Position.X;

                    if ( mLocalVertex[ i ].Position.Z < MinVertex.Z )
                        MinVertex.Z = mLocalVertex[ i ].Position.Z;
                }
            }

            SelectSize = ( MaxVertex - MinVertex ) / 2;
            ManagerPoints.Size = SelectSize;
        }

        //-------------------------------------------------------------------------//

        protected void InitIdVertex()
        {
            //----------------------------------------------
            // Id Вершин / Тип рисовния - Линии (Для 2D)
            //---------------------------------------------

            mIdVertex_Lines = new List<int>
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

            mIdVertex_Triangles = new List<int>
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
        }

        //-------------------------------------------------------------------------//

        public static ListEntity listEntity;

        public Vector3f Size = new Vector3f( 16, 16, 16 );
        public Vector3f CenterEntity = new Vector3f();
        public Vector3f SelectSize = new Vector3f();
        public Vector3f Position = new Vector3f();
        public Color DefaultColorEntity = new Color( 1, 0, 0 );
        public Color ColorEntity = new Color( 1, 0, 0 );

        private List<Vertex> mLocalVertex = new List<Vertex>();
        private List<Vector3f> mGlobalVertex = new List<Vector3f>();
        private List<int> mIdVertex_Lines = new List<int>();
        private List<int> mIdVertex_Triangles = new List<int>();
    }
}
