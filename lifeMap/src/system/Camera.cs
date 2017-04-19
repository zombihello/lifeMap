using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace lifeMap.src.system
{
    class Camera
    {
        //-------------------------------------------------------------------------//

        public Camera() { }

        //-------------------------------------------------------------------------//

        public Camera( SimpleOpenGlControl view )
        {
            View = view;
            Point centerView = View.PointToScreen( new Point( View.Width / 2, View.Height / 2 ) );
            CenterView = new Vector3f( centerView.X, centerView.Y, 0 );
        }

        //-------------------------------------------------------------------------//

        public void Update( Viewport.TypeViewport typeViewport )
        {
            Gl.glTranslatef( Position.X, Position.Y, Position.Z );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Textured_3D:
                    if ( Mouse.TypeViewportClicked == typeViewport && Program.selectTool == Program.SelectTool.CameraTool )
                    {
                        Angle.X = ( CenterView.X - Control.MousePosition.X ) / 4;
                        Angle.Y = ( CenterView.Y - Control.MousePosition.Y ) / 4;

                        if ( Angle.Y < -89.0f )
                            Angle.Y = -89.0f;
                        else if ( Angle.Y > 89.0f )
                            Angle.Y = 89.0f;

                        //Cursor.Position = View.PointToScreen( new Point( View.Width / 2, View.Height / 2 ) );
                    }

                    Glu.gluLookAt( 0, 0, 0, -Math.Sin( Angle.X / 180 * 3.14f ), Math.Tan( Angle.Y / 180 * 3.14f ), -Math.Cos( Angle.X / 180 * 3.14f ), 0, 1, 0 );
                    break;

                case Viewport.TypeViewport.Top_2D_xy:
                    Gl.glRotatef( -90, 1, 0, 0 );
                    break;

                case Viewport.TypeViewport.Front_2D_yz:
                    Gl.glRotatef( 90, 0, 1, 0 );
                    break;
            }
        }

        //-------------------------------------------------------------------------//

        public void RenderCamera()
        {
            Gl.glEnable( Gl.GL_POINT_SMOOTH );
            Gl.glPointSize( 5f );

            Gl.glBegin( Gl.GL_POINTS );
            Gl.glColor3f( 0.5f, 0.5f, 1 );

            Gl.glVertex3f( Scene.WorldCamera.Position.X, Scene.WorldCamera.Position.Y, Scene.WorldCamera.Position.Z );

            Gl.glEnd();
            Gl.glDisable( Gl.GL_POINT_SMOOTH );
        }

        //-------------------------------------------------------------------------//

        public void SetPosition( Vector3f Position )
        {
            this.Position = Position;
            Gl.glTranslatef( Position.X, Position.Y, Position.Z );
        }

        //-------------------------------------------------------------------------//

        public void SetViewport( SimpleOpenGlControl view )
        {
            View = view;
            Point centerView = View.PointToScreen( new Point( View.Width / 2, View.Height / 2 ) );
            CenterView = new Vector3f( centerView.X, centerView.Y, 0 );
        }

        //-------------------------------------------------------------------------//

        public void Move( Vector3f FactorMove )
        {
            Position.X += FactorMove.X;
            Position.Y += FactorMove.Y;
            Position.Z += FactorMove.Z;
        }

        //-------------------------------------------------------------------------//

        public Vector3f Position = new Vector3f();
        public Vector3f Angle = new Vector3f();

        private SimpleOpenGlControl View = null;
        private Vector3f CenterView = new Vector3f();
    }
}
