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
        }

        //-------------------------------------------------------------------------//

        public void Update( Viewport.TypeViewport typeViewport )
        {
            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
                Gl.glTranslatef( Position.X, Position.Y, Position.Z );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Textured_3D:
                    if ( Mouse.TypeViewportClicked == typeViewport && Program.selectTool == Program.SelectTool.CameraTool )
                    {
                        Point CenterView = View.PointToScreen( new Point( View.Width / 2, View.Height / 2 ) );

                        Angle.X += ( CenterView.X - Control.MousePosition.X ) / 4;
                        Angle.Y += ( CenterView.Y - Control.MousePosition.Y ) / 4;

                        if ( Angle.Y < -89.0f )
                            Angle.Y = -89.0f;
                        else if ( Angle.Y > 89.0f )
                            Angle.Y = 89.0f;

                        Cursor.Position = CenterView;

                        CenterPosition = new Vector3f
                            (
                            Position.X - ( float )Math.Sin( Angle.X / 180 * Math.PI ),
                            Position.Y + ( float )Math.Tan( Angle.Y / 180 * Math.PI ),
                            Position.Z - ( float )Math.Cos( Angle.X / 180 * Math.PI )
                            );
                    }

                    Glu.gluLookAt( Position.X, Position.Y, Position.Z, CenterPosition.X, CenterPosition.Y, CenterPosition.Z, 0, 1, 0 );
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
        }

        //-------------------------------------------------------------------------//

        public void SetViewport( SimpleOpenGlControl view )
        {
            View = view;
        }

        //-------------------------------------------------------------------------//

        public void Move( Keys KeyPress )
        {
            switch ( KeyPress )
            {
                case Keys.W:
                    Position.X -= ( float )Math.Sin( Angle.X / 180 * Math.PI ) * Speed;
                    Position.Y += ( float )Math.Tan( Angle.Y / 180 * Math.PI ) * Speed;
                    Position.Z -= ( float )Math.Cos( Angle.X / 180 * Math.PI ) * Speed;
                    break;

                case Keys.S:
                    Position.X += ( float )Math.Sin( Angle.X / 180 * Math.PI ) * Speed;
                    Position.Y -= ( float )Math.Tan( Angle.Y / 180 * Math.PI ) * Speed;
                    Position.Z += ( float )Math.Cos( Angle.X / 180 * Math.PI ) * Speed;
                    break;

                case Keys.A:
                    Position.X += ( float )Math.Sin( ( Angle.X - 90 ) / 180 * Math.PI ) * Speed;
                    Position.Z += ( float )Math.Cos( ( Angle.X - 90 ) / 180 * Math.PI ) * Speed;
                    break;

                case Keys.D:
                    Position.X += ( float )Math.Sin( ( Angle.X + 90 ) / 180 * Math.PI ) * Speed;
                    Position.Z += ( float )Math.Cos( ( Angle.X + 90 ) / 180 * Math.PI ) * Speed;
                    break;
            }
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
        public float Speed = 5f;

        private SimpleOpenGlControl View = null;
        private Vector3f CenterPosition = new Vector3f( 0, 0, 0 );
    }
}
