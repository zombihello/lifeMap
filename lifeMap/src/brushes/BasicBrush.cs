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
    class BasicBrush
    {
        //-------------------------------------------------------------------------//

        public BasicBrush()
        {
            mPointsResize.Add( new PointsResize( this, Viewport.TypeViewport.Front_2D_yz ) );
            mPointsResize.Add( new PointsResize( this, Viewport.TypeViewport.Side_2D_xz ) );
            mPointsResize.Add( new PointsResize( this, Viewport.TypeViewport.Top_2D_xy ) );
        }

        //-------------------------------------------------------------------------//

        public virtual void Create( Vector3f StartPosition, Vector3f EndPosition ) { }

        //-------------------------------------------------------------------------//

        public void Render( Viewport.TypeViewport typeViewport )
        {
            RenderCenterBrush( typeViewport );

            if ( Mouse.BrushSelect == this && typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                for ( int i = 0; i < mPointsResize.Count; i++ )
                    if ( mPointsResize[i].typeViewport == typeViewport )
                        mPointsResize[i].Render();
            }

            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( ColorBrush.R, ColorBrush.G, ColorBrush.B );

            for ( int i = 0; i < mIdVertex.Count; i++ )
            {
                int id = mIdVertex[i];
                Gl.glVertex3f( mGlobalVertex[id].X, mGlobalVertex[id].Y, mGlobalVertex[id].Z );
            }

            Gl.glEnd();
        }

        //-------------------------------------------------------------------------//

        public void SetPosition( Vector3f position, Viewport.TypeViewport typeViewport )
        {
            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                switch ( typeViewport )
                {
                    case Viewport.TypeViewport.Front_2D_yz:
                        Position.Y = Program.Align( position.Y - Size.Y / 2, Viewport.fSize );
                        Position.Z = Program.Align( position.X - Size.Z / 2, Viewport.fSize );
                        ToGloablCoords();
                        break;

                    case Viewport.TypeViewport.Side_2D_xz:
                        Position.X = Program.Align( position.X - Size.X / 2, Viewport.fSize );
                        Position.Y = Program.Align( position.Y - Size.Y / 2, Viewport.fSize );
                        ToGloablCoords();
                        break;

                    case Viewport.TypeViewport.Top_2D_xy:
                        Position.X = Program.Align( position.X - Size.X / 2, Viewport.fSize );
                        Position.Z = Program.Align( position.Y - Size.Z / 2, Viewport.fSize );
                        ToGloablCoords();
                        break;

                    case Viewport.TypeViewport.Textured_3D:
                        break;
                }
            }
        }

        //-------------------------------------------------------------------------//

        public void SetSize( Vector3f position, Viewport.TypeViewport typeViewport ) // TODO: Сделать изменение размеров браша
        {
            float dX = position.X - Position.X;
            Position.X += dX;
            Size.X += dX;

            Random ran = new Random();
            SetColorBrush( new Color( ran.Next( 1, 255 ) / 100, ran.Next( 1, 255 ) / 100, ran.Next( 1, 255 ) / 100 ) ); // for test

            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        private void RenderCenterBrush( Viewport.TypeViewport typeViewport )
        {
            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glColor3f( ColorBrush.R, ColorBrush.G, ColorBrush.B );

                Gl.glVertex3f( CenterBrush.X - 4, CenterBrush.Y - 4, CenterBrush.Z - 4 );
                Gl.glVertex3f( CenterBrush.X + 4, CenterBrush.Y + 4, CenterBrush.Z + 4 );

                if ( typeViewport != Viewport.TypeViewport.Front_2D_yz )
                {
                    Gl.glVertex3f( CenterBrush.X + 4, CenterBrush.Y - 4, CenterBrush.Z - 4 );
                    Gl.glVertex3f( CenterBrush.X - 4, CenterBrush.Y + 4, CenterBrush.Z + 4 );
                }
                else
                {
                    Gl.glVertex3f( CenterBrush.X + 4, CenterBrush.Y - 4, CenterBrush.Z + 4 );
                    Gl.glVertex3f( CenterBrush.X - 4, CenterBrush.Y + 4, CenterBrush.Z - 4 );
                }

                Gl.glEnd();
            }
        }

        //-------------------------------------------------------------------------//

        protected void InitBrush( Vector3f StartPosition, Vector3f EndPosition )
        {
            if ( StartPosition.X == 0 )
                StartPosition.X = Viewport.fSize;

            if ( StartPosition.Y == 0 )
                StartPosition.Y = Viewport.fSize;

            if ( StartPosition.Z == 0 )
                StartPosition.Z = Viewport.fSize;

            Position.X = Program.Align( StartPosition.X, Viewport.fSize );
            Position.Y = Program.Align( StartPosition.Y, Viewport.fSize );
            Position.Z = Program.Align( StartPosition.Z, Viewport.fSize );


            Size.X = Program.Align( EndPosition.X, Viewport.fSize ) - Position.X;
            Size.Y = Program.Align( EndPosition.Y, Viewport.fSize ) - Position.Y;
            Size.Z = Program.Align( EndPosition.Z, Viewport.fSize ) - Position.Z;
        }

        //-------------------------------------------------------------------------//

        protected void ToGloablCoords()
        {
            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                mGlobalVertex[i].X = mLocalVertex[i].X + Position.X;
                mGlobalVertex[i].Y = mLocalVertex[i].Y + Position.Y;
                mGlobalVertex[i].Z = mLocalVertex[i].Z + Position.Z;
            }

            CenterBrush.X = Position.X + Size.X / 2;
            CenterBrush.Y = Position.Y + Size.Y / 2;
            CenterBrush.Z = Position.Z + Size.Z / 2;

            for ( int i = 0; i < mPointsResize.Count; i++ )
                mPointsResize[i].InitPoints( this, mPointsResize[i].typeViewport );
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( Vector3f PositionVertex )
        {
            mLocalVertex.Add( PositionVertex );
            mGlobalVertex.Add( PositionVertex );
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( float x, float y, float z )
        {
            mLocalVertex.Add( new Vector3f( x, y, z ) );
            mGlobalVertex.Add( new Vector3f( x, y, z ) );
        }

        //-------------------------------------------------------------------------//

        protected void AddIdVertex( int id )
        {
            mIdVertex.Add( id );
        }

        //-------------------------------------------------------------------------//

        public void SetColorBrush( Color color )
        {
            ColorBrush = color;
        }

        //-------------------------------------------------------------------------//

        public void SetDefaultColorBrush( Color color )
        {
            DefaultColorBrush = color;
        }

        //-------------------------------------------------------------------------//

        public Vector3f CenterBrush = new Vector3f();
        public Vector3f Size = new Vector3f();
        public Vector3f Position = new Vector3f();
        public Color DefaultColorBrush = new Color( 1, 0, 0 );
        public List<PointsResize> mPointsResize = new List<PointsResize>();

        protected Color ColorBrush = new Color( 1, 0, 0 );

        private List<Vector3f> mLocalVertex = new List<Vector3f>();
        private List<Vector3f> mGlobalVertex = new List<Vector3f>();
        private List<int> mIdVertex = new List<int>();
    }
}
