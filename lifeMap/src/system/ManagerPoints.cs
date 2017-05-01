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

        public static void SetSelectBrush( BasicBrush Brush )
        {
            PointsClear();
            brushSelect = Brush;

            mPoints.Add( new Points( brushSelect, Viewport.TypeViewport.Top_2D_xy ) );
            mPoints.Add( new Points( brushSelect, Viewport.TypeViewport.Front_2D_yz ) );
            mPoints.Add( new Points( brushSelect, Viewport.TypeViewport.Side_2D_xz ) );
        }

        //-------------------------------------------------------------------------//

        public static void PointsUpdate()
        {
            for ( int i = 0; i < mPoints.Count; i++ )
                mPoints[i].InitPoints( brushSelect, mPoints[i].typeViewport );
        }

        //-------------------------------------------------------------------------//

        public static void PointsRender( Viewport.TypeViewport typeViewport )
        {
            for ( int i = 0; i < mPoints.Count; i++ )
                if ( mPoints[i].typeViewport == typeViewport )
                    mPoints[i].Render();
        }

        //-------------------------------------------------------------------------//

        public static void SetPointsType( PointsType PointsType )
        {
            mPoints.Clear();

            pointsType = PointsType;          
            SetSelectBrush( brushSelect );
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
                Points points = mPoints[i];

                if ( points.IsPointsClick( PositionClick ) )
                    return true;
            }

            return false;
        }

        //-------------------------------------------------------------------------//

        public static float FactorSize = 0;
        public static Vector3f Size = new Vector3f();
        public static PointsType pointsType = PointsType.Resize;
        public static Points.PointType SelectPointType;     
        public static List<Points> mPoints = new List<Points>();

        private static BasicBrush brushSelect = null;
    }
}
