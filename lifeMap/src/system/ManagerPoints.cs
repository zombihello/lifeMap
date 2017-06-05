using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lifeMap.src.brushes;

namespace lifeMap.src.system
{
    class ManagerPoints
    {
        //-------------------------------------------------------------------------//

        public enum PointsType
        {
            Resize,
            Rotate
        };

        //-------------------------------------------------------------------------//

        public ManagerPoints() { }

        //-------------------------------------------------------------------------//

        public static void SetSelect( BasicBrush Brush )
        {
            PointsClear();
            brushSelect = Brush;
            FactorShift = Brush.SelectSize;

            mPoints.Add( new Points( brushSelect, Viewport.TypeViewport.Top_2D_xz ) );
            mPoints.Add( new Points( brushSelect, Viewport.TypeViewport.Front_2D_yz ) );
            mPoints.Add( new Points( brushSelect, Viewport.TypeViewport.Side_2D_xy ) );
        }

        //-------------------------------------------------------------------------//

        public static void PointsUpdate()
        {
            for ( int i = 0; i < mPoints.Count; i++ )
                mPoints[ i ].InitPoints( brushSelect, mPoints[ i ].typeViewport );
        }

        //-------------------------------------------------------------------------//

        public static void PointsRender( Viewport.TypeViewport typeViewport )
        {
            for ( int i = 0; i < mPoints.Count; i++ )
                if ( mPoints[ i ].typeViewport == typeViewport )
                    mPoints[ i ].Render();
        }

        //-------------------------------------------------------------------------//

        public static void SetPointsType( PointsType PointsType )
        {
            if ( brushSelect != null )
            {
                mPoints.Clear();
                pointsType = PointsType;
                SetSelect( brushSelect );
            }
        }

        //-------------------------------------------------------------------------//

        public static void PointsClear()
        {
            mPoints.Clear();
            brushSelect = null;          
        }

        //-------------------------------------------------------------------------//

        public static bool IsPointsClick( Vector3f PositionClick )
        {
            for ( int i = 0; i < mPoints.Count; i++ )
            {
                Points points = mPoints[ i ];

                if ( points.IsPointsClick( PositionClick ) )
                    return true;
            }

            return false;
        }

        //-------------------------------------------------------------------------//

        public static float SizePoint = 6;
        public static PointsType pointsType = PointsType.Resize;
        public static Points.PointType SelectPointType;
        public static Vector3f FactorShift = new Vector3f();

        private static BasicBrush brushSelect = null;
        private static List<Points> mPoints = new List<Points>();
    }
}
