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
            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( colorBrush.R, colorBrush.G, colorBrush.B );

            for ( int i = 0; i < mIdVertex.Count; i++ )
            {
                int id = mIdVertex[i];
                Gl.glVertex3f( mVertex[id].X, mVertex[id].Y, mVertex[id].Z );
            }

            Gl.glEnd();
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

        protected Vector3f Size = new Vector3f();
        protected Color colorBrush = new Color( 1, 0, 0 );

        private Vector3f StartPosition = new Vector3f();
        private List<Vector3f> mVertex = new List<Vector3f>();
        private List<int> mIdVertex = new List<int>();
    }
}
