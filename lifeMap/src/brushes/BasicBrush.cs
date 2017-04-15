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
            Gl.glColor3f( 1, 0, 0 );
            
            for ( int i = 0; i < Mesh.Count; i++ )
                Gl.glVertex3f( Mesh[i].X, Mesh[i].Y, Mesh[i].Z );

            Gl.glEnd();

        }

        //-------------------------------------------------------------------------//

        protected void InitBrush( Vector3f StartPosition, Vector3f EndPosition )
        {
            EndPosition.X = Program.Align( EndPosition.X, Viewport.fSize );
            EndPosition.Y = Program.Align( EndPosition.Y, Viewport.fSize );
            EndPosition.Z = Program.Align( EndPosition.Z, Viewport.fSize );

            Size.X = EndPosition.X - StartPosition.X;
            Size.Y = EndPosition.Y - StartPosition.Y;
            Size.Z = EndPosition.Z - StartPosition.Z;
        }

        //-------------------------------------------------------------------------//

        public List<Vector3f> Mesh = new List<Vector3f>();

        protected Vector3f Size = new Vector3f();
    }
}
