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

        public enum PointType
        {
            LeftCenter,
            RightCenter,
            TopCenter,
            BottomCenter,
            LeftBottom,
            LeftTop,
            RightBottom,
            RightTop
        };

        //-------------------------------------------------------------------------//

        public PointsResize( BasicBrush SelectBrush, Viewport.TypeViewport typeViewport )
        {
            InitPoints( SelectBrush, typeViewport );
            this.typeViewport = typeViewport;

            mTypePoint.Add( PointType.LeftCenter ); // Left Center
            mTypePoint.Add( PointType.RightCenter ); // Right Center
            mTypePoint.Add( PointType.TopCenter ); // Top Center
            mTypePoint.Add( PointType.BottomCenter ); // Bottom Center
            mTypePoint.Add( PointType.LeftBottom ); // Left Bottom
            mTypePoint.Add( PointType.LeftTop ); // Left Top
            mTypePoint.Add( PointType.RightBottom ); // Right Bottom
            mTypePoint.Add( PointType.RightTop ); // Right Top
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
            Vector3f Size = new Vector3f(
               Math.Abs( CenterBrush.X - SelectBrush.Position.X ),
               Math.Abs( CenterBrush.Y - SelectBrush.Position.Y ),
               Math.Abs( CenterBrush.Z - SelectBrush.Position.Z ) );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Front_2D_yz:
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z - Size.Z ) ); // Left Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z + Size.Z ) ); // Right Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y, CenterBrush.Z ) ); // Top Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y, CenterBrush.Z ) ); // Bottom Center

                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y, CenterBrush.Z - Size.Z ) ); // Left Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y, CenterBrush.Z - Size.Z ) ); // Left Top

                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y, CenterBrush.Z + Size.Z ) ); // Right Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y, CenterBrush.Z + Size.Z ) ); // Right Top
                    break;

                case Viewport.TypeViewport.Side_2D_xz:
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X, CenterBrush.Y, CenterBrush.Z ) ); // Left Center
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X, CenterBrush.Y, CenterBrush.Z ) ); // Right Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y + Size.Y, CenterBrush.Z ) ); // Top Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y - Size.Y, CenterBrush.Z ) ); // Bottom Center

                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X, CenterBrush.Y - Size.Y, CenterBrush.Z ) ); // Left Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X, CenterBrush.Y + Size.Y, CenterBrush.Z ) ); // Left Top

                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X, CenterBrush.Y - Size.Y, CenterBrush.Z ) ); // Right Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X, CenterBrush.Y + Size.Y, CenterBrush.Z ) ); // Right Top
                    break;

                case Viewport.TypeViewport.Top_2D_xy:
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X, CenterBrush.Y, CenterBrush.Z ) ); // Left Center
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X, CenterBrush.Y, CenterBrush.Z ) ); // Right Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z + Size.Z ) ); // Top Center
                    mPoints.Add( new Vector3f( CenterBrush.X, CenterBrush.Y, CenterBrush.Z - Size.Z ) ); // Bottom Center

                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X, CenterBrush.Y, CenterBrush.Z - Size.Z ) ); // Left Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X - Size.X, CenterBrush.Y, CenterBrush.Z + Size.Z ) ); // Left Top

                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X, CenterBrush.Y, CenterBrush.Z - Size.Z ) ); // Right Bottom
                    mPoints.Add( new Vector3f( CenterBrush.X + Size.X, CenterBrush.Y, CenterBrush.Z + Size.Z ) ); // Right Top
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
                        {
                            SelectPointType = mTypePoint[i];
                            return true;
                        }
                        break;

                    case Viewport.TypeViewport.Side_2D_xz:
                        if ( PositionClick.X <= PositionPoint.X + 5 &&
                             PositionClick.X >= PositionPoint.X - 5 &&
                             PositionClick.Y <= PositionPoint.Y + 5 &&
                             PositionClick.Y >= PositionPoint.Y - 5 )
                        {
                            SelectPointType = mTypePoint[i];
                            return true;
                        }
                        break;

                    case Viewport.TypeViewport.Top_2D_xy:
                        if ( PositionClick.X <= PositionPoint.X + 5 &&
                             PositionClick.X >= PositionPoint.X - 5 &&
                             PositionClick.Y <= PositionPoint.Z + 5 &&
                             PositionClick.Y >= PositionPoint.Z - 5 )
                        {
                            SelectPointType = mTypePoint[i];
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        //-------------------------------------------------------------------------//

        public static PointType SelectPointType;

        public Viewport.TypeViewport typeViewport;
        public List<Vector3f> mPoints = new List<Vector3f>();
        public List<PointType> mTypePoint = new List<PointType>();
    }

    //-------------------------------------------------------------------------//
}
