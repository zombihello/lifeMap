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
        public Camera( SimpleOpenGlControl view )
        {
            View = view;
        }

        //-------------------------------------------------------------------------//

        public void Update( Viewport.TypeViewport typeViewport )
        {
            Angle.X = View.Width / 2 - System.Windows.Forms.Cursor.Position.X;
            Angle.Y = View.Height / 2 - System.Windows.Forms.Cursor.Position.Y;

            if ( Angle.Y < -89.0f )
                Angle.Y = -89.0f;
            else if ( Angle.Y > 89.0f )
                Angle.Y = 89.0f;

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Textured_3D:
                    Glu.gluLookAt( 0, 0, 0, -Math.Sin( Angle.X / 180 * 3.14f ), Math.Tan( Angle.Y / 180 * 3.14f ), -Math.Cos( Angle.X / 180 * 3.14f ), 0, 1, 0 );
                    break;
            }
        }

        //-------------------------------------------------------------------------//

        public void SetPosition( Vector3f Position )
        {
            PositionCamera = Position;
        }

        //-------------------------------------------------------------------------//

        private SimpleOpenGlControl View = null;
        private Vector3f PositionCamera = new Vector3f();
        private Vector3f Angle = new Vector3f();
    }
}
