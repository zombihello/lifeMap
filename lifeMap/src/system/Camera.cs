using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace lifeMap.src.system
{
    class Camera
    {
        //-------------------------------------------------------------------------//

        public Camera( SimpleOpenGlControl view )
        {
            View = view;
        }

        //-------------------------------------------------------------------------//

        public void Update( Viewport.TypeViewport typeViewport )
        {
            Gl.glTranslatef( Position.X, Position.Y, Position.Z );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Textured_3D:
                    if ( Program.selectTool == Program.SelectTool.CameraTool )
                    {
                        Angle.X = View.Width / 2 - System.Windows.Forms.Cursor.Position.X;
                        Angle.Y = View.Height / 2 - System.Windows.Forms.Cursor.Position.Y;

                        if ( Angle.Y < -89.0f )
                            Angle.Y = -89.0f;
                        else if ( Angle.Y > 89.0f )
                            Angle.Y = 89.0f;
                    }

                    Glu.gluLookAt( Position.X, Position.Y, Position.Z, Position.X - Math.Sin( Angle.X / 180 * 3.14f ), Position.Y + Math.Tan( Angle.Y / 180 * 3.14f ), Position.Z- Math.Cos( Angle.X / 180 * 3.14f ), 0, 1, 0 );
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

        public void Move( Vector3f FactorMove )
        {
            Position.X += FactorMove.X;
            Position.Y += FactorMove.Y;
            Position.Z += FactorMove.Z;
        }

        //-------------------------------------------------------------------------//

        private SimpleOpenGlControl View = null;
        public Vector3f Position = new Vector3f();
        public Vector3f Angle = new Vector3f();
    }
}
