using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.brushes;

namespace lifeMap.src.system
{
    //-------------------------------------------------------------------------//

    class PointsResize
    {
        //-------------------------------------------------------------------------//

        public PointsResize( BasicBrush SelectBrush, Viewport.TypeViewport typeViewport )
        {
            InitPoints( SelectBrush, typeViewport );
            this.typeViewport = typeViewport;
        }

        //-------------------------------------------------------------------------//

        public void Render()
        {
            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                Gl.glPointSize( 8 );
                Gl.glBegin( Gl.GL_POINTS );
                Gl.glColor3f( 1, 1, 1 );

                for ( int i = 0; i < mPoints.Count; i++ )
                    Gl.glVertex3f( mPoints[i].X, mPoints[i].Y, mPoints[i].Z );

                Gl.glEnd();
            }
        }

        //-------------------------------------------------------------------------//

        public void InitPoints( BasicBrush SelectBrush, Viewport.TypeViewport typeViewport )
        {
            mPoints.Clear();

            Vector3f CenterBrush = SelectBrush.CenterBrush;
            Vector3f Size = SelectBrush.Size;

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Front_2D_yz:
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z - Size.Z / 2 ) ); // Left Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z + Size.Z / 2 ) ); // Right Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y / 2, CenterBrush.Z ) ); // Top Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y / 2, CenterBrush.Z ) ); // Bottom Center

                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y / 2, CenterBrush.Z - Size.Z / 2 ) ); // Left Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y / 2, CenterBrush.Z - Size.Z / 2 ) ); // Left Top

                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y / 2, CenterBrush.Z + Size.Z / 2 ) ); // Right Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y / 2, CenterBrush.Z + Size.Z / 2 ) ); // Right Top                
                    break;

                case Viewport.TypeViewport.Side_2D_xz:
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X / 2, CenterBrush.Y, CenterBrush.Z ) ); // Left Center
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X / 2, CenterBrush.Y, CenterBrush.Z ) ); // Right Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y / 2, CenterBrush.Z ) ); // Top Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y / 2, CenterBrush.Z ) ); // Bottom Center

                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X / 2, CenterBrush.Y - Size.Y / 2, CenterBrush.Z ) ); // Left Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X / 2, CenterBrush.Y + Size.Y / 2, CenterBrush.Z ) ); // Left Top

                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X / 2, CenterBrush.Y + Size.Y / 2, CenterBrush.Z ) ); // Right Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X / 2, CenterBrush.Y - Size.Y / 2, CenterBrush.Z ) ); // Right Top
                    break;

                case Viewport.TypeViewport.Top_2D_xy:
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X / 2, CenterBrush.Y, CenterBrush.Z ) ); // Left Center
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X / 2, CenterBrush.Y, CenterBrush.Z ) ); // Right Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z + Size.Z / 2 ) ); // Top Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z - Size.Z / 2 ) ); // Bottom Center

                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X / 2, CenterBrush.Y, CenterBrush.Z - Size.Z / 2 ) ); // Left Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X / 2, CenterBrush.Y, CenterBrush.Z + Size.Z / 2 ) ); // Left Top

                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X / 2, CenterBrush.Y, CenterBrush.Z + Size.Z / 2 ) ); // Right Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X / 2, CenterBrush.Y, CenterBrush.Z - Size.Z / 2 ) ); // Right Top
                    break;
            }
        }

        //-------------------------------------------------------------------------//

        public bool IsPointsClick( Vector3f PositionClick )
        {
            for ( int i = 0; i < mPoints.Count; i++ )
            {
                Vector3f PositionPoint = mPoints[i];

                switch ( typeViewport )
                {
                    case Viewport.TypeViewport.Front_2D_yz:
                        if ( PositionClick.X <= PositionPoint.Z + 5 &&
                             PositionClick.X >= PositionPoint.Z - 5 &&
                             PositionClick.Y <= PositionPoint.Y + 5 &&
                             PositionClick.Y >= PositionPoint.Y - 5 )
                            return true;
                        break;

                    case Viewport.TypeViewport.Side_2D_xz:
                        if ( PositionClick.X <= PositionPoint.X + 5 &&
                             PositionClick.X >= PositionPoint.X - 5 &&
                             PositionClick.Y <= PositionPoint.Y + 5 &&
                             PositionClick.Y >= PositionPoint.Y - 5 )
                            return true;
                        break;

                    case Viewport.TypeViewport.Top_2D_xy:
                        if ( PositionClick.X <= PositionPoint.X + 5 &&
                             PositionClick.X >= PositionPoint.X - 5 &&
                             PositionClick.Y <= PositionPoint.Z + 5 &&
                             PositionClick.Y >= PositionPoint.Z - 5 )
                            return true;
                        break;
                }
            }
            return false;
        }

        //-------------------------------------------------------------------------//

        public List<Vector3f> mPoints = new List<Vector3f>();
        public Viewport.TypeViewport typeViewport;
    }

    //-------------------------------------------------------------------------//
}
