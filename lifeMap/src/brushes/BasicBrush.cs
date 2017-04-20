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

        public virtual void Create( Vector3f StartPosition, Vector3f EndPosition ) { }

        //-------------------------------------------------------------------------//

        public void Render( Viewport.TypeViewport typeViewport )
        {
            RenderCenterBrush( typeViewport );

            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( ColorBrush.R, ColorBrush.G, ColorBrush.B );

            for ( int i = 0; i < mIdVertex.Count; i++ )
            {
                int id = mIdVertex[i];
                Gl.glVertex3f( mVertex[id].X, mVertex[id].Y, mVertex[id].Z );
            }

            Gl.glEnd();
        }

        //-------------------------------------------------------------------------//

        protected void RenderCenterBrush( Viewport.TypeViewport typeViewport )
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

            Size.X = EndPosition.X - StartPosition.X;
            Size.Y = EndPosition.Y - StartPosition.Y;
            Size.Z = EndPosition.Z - StartPosition.Z;

            CenterBrush = new Vector3f( StartPosition.X + Size.X / 2f, StartPosition.Y + Size.Y/2, StartPosition.Z + Size.Z / 2f );

            this.StartPosition = StartPosition;
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( Vector3f PositionVertex )
        {
            mVertex.Add( PositionVertex );
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( float x, float y, float z )
        {
            mVertex.Add( new Vector3f( x, y, z ) );
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

        public Vector3f CenterBrush = new Vector3f();

        protected Vector3f Size = new Vector3f();      
        protected Color ColorBrush = new Color( 1, 0, 0 );

        private Vector3f StartPosition = new Vector3f();
        private List<Vector3f> mVertex = new List<Vector3f>();
        private List<int> mIdVertex = new List<int>();
    }
}
